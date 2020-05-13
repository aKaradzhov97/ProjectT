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
            return await this.repositoryProduct.All()
                .To<ProductsInputViewModel>()
                .OrderByDescending(x => x.Created_On)
                .Take(6)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductsInputViewModel>> Trending()
        {
            return await this.repositoryProduct.All()
                .To<ProductsInputViewModel>()
                .OrderByDescending(x => x.SellCount)
                .Take(6)
                .ToListAsync();
        }
    }
}