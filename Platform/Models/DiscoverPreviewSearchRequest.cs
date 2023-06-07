using System.Collections.Generic;

namespace Platform.Models
{
    public class ContentParameters
    {
        public ProductParameters product { get; set; }
    }

    public class ContextParameters
    {
        public PageParameters page { get; set; }
    }

    public class Data
    {
        public WidgetParameters widget { get; set; }
        public ContextParameters context { get; set; }
        public QueryParameters query { get; set; }
        public ContentParameters content { get; set; }
    }

    public class Keyphrase
    {
        public List<string> value { get; set; }
    }

    public class PageParameters
    {
        public string locale_country { get; set; }
        public string locale_language { get; set; }
    }

    public class ProductParameters
    {
    }

    public class QueryParameters
    {
        public Keyphrase keyphrase { get; set; }
    }

    public class DiscoverPreviewSearchRequest
    {
        public Data data { get; set; }
    }

    public class WidgetParameters
    {
        public string rfkid { get; set; }
    }


}
