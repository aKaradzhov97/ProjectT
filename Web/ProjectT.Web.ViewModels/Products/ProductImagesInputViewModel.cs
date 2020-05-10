using System.ComponentModel.DataAnnotations;

namespace ProjectT.Web.ViewModels.Products
{
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ProductImagesInputViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}