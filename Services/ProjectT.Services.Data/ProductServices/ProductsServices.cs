namespace ProjectT.Services.Data.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public class ProductsServices : IProductsServices
    {
        private readonly IRepository<Product> repositoryProduct;

        public ProductsServices(IRepository<Product> repositoryProduct)
        {
            this.repositoryProduct = repositoryProduct;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await this.repositoryProduct.All().ToListAsync();
        }

        // TO DO PLEASE IMPLEMENTING
        public async Task<IEnumerable<Product>> CreateProduct(ProductsInputViewModel product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity,
                Created_On = DateTime.UtcNow,
                SellCount = 0,
            };

            await this.repositoryProduct.AddAsync(newProduct);
            await this.repositoryProduct.SaveChangesAsync();

            return await this.GetAllProducts();
        }
    }
}