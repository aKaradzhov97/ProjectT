namespace ProjectT.Services.Data.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public class ProductsServices : IProductsServices
    {
        private readonly IRepository<Product> repositoryProduct;
        private readonly IRepository<Image> repositoryImage;

        public ProductsServices(
            IRepository<Product> repositoryProduct,
            IRepository<Image> repositoryImage)
        {
            this.repositoryProduct = repositoryProduct;
            this.repositoryImage = repositoryImage;
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
            if (product.Images != null)
            {
                newProduct.Images.AddRange(product.Images);
            }

            await this.repositoryProduct.AddAsync(newProduct);
            await this.repositoryProduct.SaveChangesAsync();

            return await this.GetAllProducts();
        }

        public async Task<IEnumerable<Image>> TakeProductImages(string id)
        {
            var allImages = await this.repositoryImage.All()
                .Where(x => x.ProductId == id).ToListAsync();

            return allImages;
        }

        public async Task<IEnumerable<Product>> DeleteProduct(string id)
        {
            var currentProduct = await this.repositoryProduct.All().FirstOrDefaultAsync(x => x.Id == id);

            var currentImages = await this.repositoryImage.All().Where(x => x.ProductId == id).ToListAsync();

            if (currentImages != null)
            {
                foreach (var image in currentImages)
                {
                    this.repositoryImage.Delete(image);
                    await this.repositoryProduct.SaveChangesAsync();
                }
            }

            if (currentProduct != null)
            {
                this.repositoryProduct.Delete(currentProduct);
                await this.repositoryProduct.SaveChangesAsync();
            }

            return await this.repositoryProduct.All().ToListAsync();
        }
    }
}