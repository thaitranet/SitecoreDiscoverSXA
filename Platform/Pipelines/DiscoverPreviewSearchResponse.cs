using System.Collections.Generic;

namespace Platform.Pipelines
{
    public class Content
    {
        public Product product { get; set; }
    }

    public class CustomSpecificationsAu
    {
        public string class_id { get; set; }
        public string class_friendly_name { get; set; }
        public string emc_version { get; set; }
        public string colour { get; set; }
        public string material { get; set; }
        public string with_backside_door { get; set; }
        public string with_ventilation_door { get; set; }
        public string suitable_for_outdoor_set_up { get; set; }
        public string impact_strength { get; set; }
        public string with_glazed_door { get; set; }
        public string number_of_locks { get; set; }
        public string number_of_doors { get; set; }
        public string pitched_roof { get; set; }
        public string with_mounting_plate { get; set; }
        public string pole_fastening { get; set; }
        public string suitable_for_wall_mounting { get; set; }
        public string mounting_plate_depth_adjustable { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string width { get; set; }
        public string degree_of_protection_ip { get; set; }
    }

    public class CustomSpecificationsNz
    {
        public string class_id { get; set; }
        public string class_friendly_name { get; set; }
        public string emc_version { get; set; }
        public string colour { get; set; }
        public string material { get; set; }
        public string with_backside_door { get; set; }
        public string with_ventilation_door { get; set; }
        public string suitable_for_outdoor_set_up { get; set; }
        public string impact_strength { get; set; }
        public string with_glazed_door { get; set; }
        public string number_of_locks { get; set; }
        public string number_of_doors { get; set; }
        public string pitched_roof { get; set; }
        public string with_mounting_plate { get; set; }
        public string pole_fastening { get; set; }
        public string suitable_for_wall_mounting { get; set; }
        public string mounting_plate_depth_adjustable { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string width { get; set; }
        public string degree_of_protection_ip { get; set; }
    }

    public class Product
    {
        public int total_item { get; set; }
        public List<Value> value { get; set; }
        public int n_item { get; set; }
    }

    public class Query2id
    {
        public string keyphrase { get; set; }
    }

    public class DiscoverPreviewSearchResponse
    {
        public Query2id query2id { get; set; }
        public Content content { get; set; }
        public int n_item { get; set; }
        public int total_item { get; set; }
        public int page_number { get; set; }
        public int total_page { get; set; }
        public Widget widget { get; set; }
        public string rid { get; set; }
        public string url { get; set; }
        public long ts { get; set; }
        public int dt { get; set; }
    }

    public class Value
    {
        public string custom_brand { get; set; }
        public string brand_code { get; set; }
        public string image_url { get; set; }
        public List<string> all_category_ids { get; set; }
        public List<string> category_names { get; set; }
        public string custom_is_group_600 { get; set; }
        public string product_type { get; set; }
        public string release_date { get; set; }
        public string available_nz { get; set; }
        public List<string> all_category_names { get; set; }
        public string custom_item_group { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public List<string> category_ids { get; set; }
        public string product_group { get; set; }
        public string available_au { get; set; }
        public string stock_unit { get; set; }
        public string breadcrumbs { get; set; }
        public string product_url { get; set; }
        public string custom_long_description { get; set; }
        public string custom_etim_class { get; set; }
        public string custom_web_product_status { get; set; }
        public string custom_company { get; set; }
        public string description { get; set; }
        public string custom_product_range { get; set; }
        public string custom_etim_class_id { get; set; }
        public string sku { get; set; }
        public int skuid { get; set; }
        public string price { get; set; }
        public string final_price { get; set; }
        public CustomSpecificationsNz custom_specifications_nz { get; set; }
        public CustomSpecificationsAu custom_specifications_au { get; set; }
    }

    public class Widget
    {
        public string rfkid { get; set; }
        public string used_in { get; set; }
        public string variation_id { get; set; }
        public string type { get; set; }
    }
}
