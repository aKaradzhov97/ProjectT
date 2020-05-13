namespace ProjectT.Services.Data.ProductServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;
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

        public async Task<IEnumerable<ProductsInputViewModel>> GetAllProducts()
        {
            return await this.repositoryProduct.All().To<ProductsInputViewModel>().ToListAsync();
        }

        public async Task<ProductsInputViewModel> CreateProduct(ProductsInputViewModel product)
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

            if (product.Images != null && product.Images.Count != 0)
            {
                foreach (var image in product.Images)
                {
                    var newImage = new Image
                    {
                        ImageUrl = image.ImageUrl,
                        ProductId = newProduct.Id,
                    };

                    await this.repositoryImage.AddAsync(newImage);
                    await this.repositoryImage.SaveChangesAsync();
                }
            }

            return await this.repositoryProduct.All().To<ProductsInputViewModel>().FirstOrDefaultAsync();
        }

        public async Task<Product> EditProduct(string id, ProductsInputViewModel product)
        {
            var currentProduct = await this.repositoryProduct.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (currentProduct != null)
            {
                this.repositoryProduct.Delete(currentProduct);

                currentProduct = new Product
                {
                    Id = id,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    Created_On = DateTime.UtcNow,
                    SellCount = product.SellCount,
                };

                if (product.Images != null && product.Images.Count != 0)
                {
                    foreach (var image in product.Images)
                    {
                        var currentImage = await this.repositoryImage.All().FirstOrDefaultAsync(x => x.ProductId == id);
                        if (currentImage != null)
                        {
                            this.repositoryImage.Delete(currentImage);
                            currentImage = new Image
                            {
                                Id = image.Id,
                                ImageUrl = image.ImageUrl,
                                ProductId = id,
                            };

                            await this.repositoryImage.AddAsync(currentImage);
                        }
                    }
                }

                await this.repositoryImage.SaveChangesAsync();
            }

            await this.repositoryProduct.AddAsync(currentProduct);
            await this.repositoryProduct.SaveChangesAsync();

            return currentProduct;
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