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
    using ProjectT.Web.ViewModels.Products.InputViewModels;
    using ProjectT.Web.ViewModels.Products.OutputViewModels;

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

        public async Task<IEnumerable<ProductsOutputViewModel>> GetAllProducts()
        {
            return await this.repositoryProduct.All().To<ProductsOutputViewModel>().ToListAsync();
        }

        public async Task<ProductsOutputViewModel> CreateProduct(ProductsInputViewModel product)
        {
            var size = this.CheckSize(product.Size);

            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity,
                Created_On = DateTime.UtcNow,
                Size = size,
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
                        Url = image.Url,
                        ProductId = newProduct.Id,
                    };

                    await this.repositoryImage.AddAsync(newImage);
                    await this.repositoryImage.SaveChangesAsync();
                }
            }

            return await this.repositoryProduct.All().To<ProductsOutputViewModel>()
                .FirstOrDefaultAsync(x => x.Id == newProduct.Id);
        }

        public async Task<ProductsOutputViewModel> EditProduct(string id, ProductsInputViewModel product)
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
                    Size = this.CheckSize(product.Size),
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
                                Url = image.Url,
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

            return await this.repositoryProduct.All().To<ProductsOutputViewModel>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ProductsOutputViewModel>> DeleteProduct(string id)
        {
            var currentImages = await this.repositoryImage.All().Where(x => x.ProductId == id).ToListAsync();

            if (currentImages != null)
            {
                foreach (var image in currentImages)
                {
                    this.repositoryImage.Delete(image);
                    await this.repositoryProduct.SaveChangesAsync();
                }
            }

            var currentProduct = await this.repositoryProduct.All().FirstOrDefaultAsync(x => x.Id == id);

            if (currentProduct != null)
            {
                this.repositoryProduct.Delete(currentProduct);
                await this.repositoryProduct.SaveChangesAsync();
            }

            return await this.repositoryProduct.All().To<ProductsOutputViewModel>().ToListAsync();
        }

        private string CheckSize(string size)
        {
            if (string.IsNullOrWhiteSpace(size))
            {
                return "None";
            }
            if (size.ToLower() == "xs")
            {
                return "XS";
            }
            else if (size.ToLower() == "s")
            {
                return "S";
            }
            else if (size.ToLower() == "m")
            {
               return "M";
            }
            else if (size.ToLower() == "l")
            {
                return "L";
            }
            else if (size.ToLower() == "xl")
            {
                return "XL";
            }
            else if (size.ToLower() == "xxl")
            {
                return "XXL";
            }
            else
            {
                return "None";
            }
        }
    }
}