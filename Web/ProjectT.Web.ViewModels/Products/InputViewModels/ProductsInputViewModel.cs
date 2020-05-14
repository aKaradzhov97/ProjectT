namespace ProjectT.Web.ViewModels.Products.InputViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ProductsInputViewModel : IMapFrom<Product>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Product name is required!")]
        [StringLength(200, ErrorMessage = "Product name must be between 4 and 200 characters long!", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required!")]
        [StringLength(4000, ErrorMessage = "Product description must be between 10 and 4000 characters long!", MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Images is required!")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Product price is required!")]
        [Range(0.01, 100000.00, ErrorMessage = "Product price must be between 0.01 and 100 000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product quantity is required!")]
        [Range(1, 100000, ErrorMessage = "Product quantity must be between 1 and 100 000")]
        public int Quantity { get; set; }

        public DateTime Created_On { get; set; }

        public string Size { get; set; }

        public int SellCount { get; set; }

        public List<ImagesInputViewModel> Images { get; set; }
    }
}