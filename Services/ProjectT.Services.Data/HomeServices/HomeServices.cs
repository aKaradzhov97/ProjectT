using ProjectT.Services.Mapping;

namespace ProjectT.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public class HomeServices : IHomeServices
    {
        private readonly IRepository<Product> repositoryProduct;

        public HomeServices(IRepository<Product> repositoryProduct)
        {
            this.repositoryProduct = repositoryProduct;
        }

        public async Task<IEnumerable<ProductsInputViewModel>> Newest()
        {
            var newest = await this.repositoryProduct.All()
                .To<ProductsInputViewModel>()
                .OrderByDescending(x => x.Created_On)
                .Take(6)
                .ToListAsync();

            foreach (var image in newest.Select(x => x.Images))
            {
                var data = new ImagesInputViewModel
                {
                    ImageUrl = newest.Select(a => a.Image).FirstOrDefault(),
                };

                if (!image.Contains(data))
                {
                    image.Insert(0, data);
                    break;
                }
            }

            return newest;
        }

        public async Task<IEnumerable<ProductsInputViewModel>> Trending()
        {
            var trending = await this.repositoryProduct.All()
                .To<ProductsInputViewModel>()
                .OrderByDescending(x => x.SellCount)
                .Take(6)
                .ToListAsync();

            foreach (var image in trending.Select(x => x.Images))
            {
                var data = new ImagesInputViewModel
                {
                    ImageUrl = trending.Select(a => a.Image).FirstOrDefault(),
                };

                if (!image.Contains(data))
                {
                    image.Insert(0, data);
                    break;
                }
            }

            return trending;
        }
    }
}