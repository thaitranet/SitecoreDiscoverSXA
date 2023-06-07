using Newtonsoft.Json;
using Sitecore.XA.Feature.Search.Attributes;
using Sitecore.XA.Feature.Search.Binder;
using Sitecore.XA.Feature.Search.Controllers;
using Sitecore.XA.Feature.Search.Filters;
using Sitecore.XA.Feature.Search.Models;
using Sitecore.XA.Foundation.Search.Models.Binding;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Platform.Pipelines
{
    [JsonFormatter]
    public class XASearchOverrideController : SearchController
    {
        private readonly object DISCOVER_DOMAIN_ID = "";
        private readonly string DISCOVER_AUTHORIZATION_KEY = "";

        [RegisterSearchEvent]
        [CacheWebApi]
        public async Task<ResultSet> GetResultsOverride([ModelBinder(BinderType = typeof(QueryModelBinder))] QueryModel model)
        {
            var searchResults = base.GetResults(model);
            var discoverSearchResults = await PerformDiscoverPreviewSearch(model);
            if(discoverSearchResults != null)
            {
                searchResults.Results = Enumerable.Concat(discoverSearchResults, searchResults.Results);
            }
            return searchResults;
        }

        public async Task<IEnumerable<DiscoverPreviewSearchResult>> PerformDiscoverPreviewSearch(QueryModel model)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api-apse2.rfksrv.com/search-rec/{DISCOVER_DOMAIN_ID}/3");            
            request.Headers.Add("authorization", DISCOVER_AUTHORIZATION_KEY);

            var parameters = new DiscoverPreviewSearchRequest
            {
                data = new Data
                {
                    widget = new WidgetParameters
                    {
                        rfkid = "rfkid_6"
                    },
                    context = new ContextParameters
                    {
                        page = new PageParameters
                        {
                            locale_country = "au",
                            locale_language = "en"
                        }
                    },
                    query = new QueryParameters
                    {
                        keyphrase = new Keyphrase
                        {
                            value = new List<string> { model.Query }
                        }
                    },
                    content = new ContentParameters
                    {
                        product = new ProductParameters { }
                    }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(parameters), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<DiscoverPreviewSearchResponse>(jsonResponse);


            if (result?.content?.product?.value != null)
            {
                return result.content.product.value.Select(delegate (Value item) {
                    return new DiscoverPreviewSearchResult
                    {
                        Name = item.name,
                        Url = item.product_url,                        
                        Image = item.image_url,
                        Html = $"\r\n<div class=\"product-summary\" data-id=\"7042142\">\r\n    \r\n    \r\n    <div class=\"product-photo\">\r\n        \r\n        <a title=\"Optix USB Smart Card Reader\" href=\"/Catalogs/Habitat_Master/Habitat_Master-Departments/Habitat_Master-Cameras/7042142\">\r\n            <img src=\"https://placehold.co/220\" alt=\"\" />\r\n            \r\n            <div data-bind=\"css: {{ 'promotion': promotion }}\"\r\n                class=\"hidden \">\r\n                \r\n                <span data-bind=\"text: promotion\" class=\"savings-percentage\">0%</span>\r\n                <span class=\"savings-label\">off</span>\r\n            </div>\r\n        </a>\r\n    </div>\r\n    \r\n    <div class=\"product-info\">\r\n        \r\n        <a class=\"product-title\" title=\"Optix USB Smart Card Reader\" href=\"/Catalogs/Habitat_Master/Habitat_Master-Departments/Habitat_Master-Cameras/7042142\">\r\n            {item.id}\r\n        </a>\r\n        <div class=\"product-brand\">\r\n            Sitecore Discover\r\n        </div>\r\n        \r\n        <div class=\"product-indicator\">\r\n            \r\n            <label class=\"hidden  \"\r\n                data-bind=\"css: {{ 'price-difference': hasDifferentPrice }}\">\r\n                Starting from\r\n            </label>\r\n            <label class=\"stock-status\" data-bind=\"text: stockLabel\">In-Stock</label>\r\n        </div>\r\n        \r\n        <div class=\"product-detail \"\r\n            data-bind=\"css: {{ 'on-sale': promotion }}\">\r\n            \r\n            <span data-bind=\"text: price\" class=\"product-price\">30.79 USD</span>\r\n            <a class=\"product-link\" title=\"Optix USB Smart Card Reader\" href=\"/Catalogs/Habitat_Master/Habitat_Master-Departments/Habitat_Master-Cameras/7042142\">\r\n                Details\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n"
                    };
                });
            }

            return null;
        }
    }
}
