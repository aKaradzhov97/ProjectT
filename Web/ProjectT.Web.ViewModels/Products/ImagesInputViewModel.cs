namespace ProjectT.Web.ViewModels.Products
{
    using Newtonsoft.Json;
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ImagesInputViewModel : IMapFrom<Image>
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        [JsonIgnore]
        public string ProductId { get; set; }
    }
}