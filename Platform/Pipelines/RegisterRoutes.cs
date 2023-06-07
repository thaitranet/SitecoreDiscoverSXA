using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Pipelines;
using Sitecore.XA.Foundation.Multisite;
using Sitecore.XA.Foundation.SitecoreExtensions.Session;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace Platform.Pipelines
{
    public class RegisterRoutes
    {
        public void Process(PipelineArgs args)
        {
            foreach (string virtualdir in ServiceLocator.ServiceProvider.GetService<ISiteInfoResolver>()
                .Sites.Select(s => s.VirtualFolder.Trim('/')).Distinct())
            {
                string sitepath = virtualdir.Length > 0 ? virtualdir + "/" : virtualdir;
                RouteTable.Routes.MapHttpRoute(
                    name: sitepath + "sxaresults",
                    routeTemplate: sitepath + "sxa/search/results",
                    defaults: new { controller = "XASearchOverride", action = "GetResultsOverride" }
                ).RouteHandler = new SessionHttpControllerRouteHandler();
            }
        }
    }
}