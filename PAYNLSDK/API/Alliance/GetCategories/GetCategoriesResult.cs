using System.Collections.Generic;
using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.GetCategories
{
    /// <summary>
    /// Result class for GetCategories call
    /// </summary>
    public class GetCategoriesResult : ResponseBase
    {
        /// <summary>
        /// List of categories
        /// </summary>
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; } = new List<Category>();
    }

    /// <summary>
    /// Category information
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
