namespace ProjectT.Web.ViewModels.Products.OutputViewModels
{
    using System;
    using System.Collections.Generic;

    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ProductsOutputViewModel : IMapFrom<Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime Created_On { get; set; }

        public string Size { get; set; }

        public int SellCount { get; set; }

        public List<ImagesOutputViewModel> Images { get; set; }
    }
}