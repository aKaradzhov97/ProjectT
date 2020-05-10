namespace ProjectT.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;

    public class HomeServices : IHomeServices
    {
        private readonly IRepository<Product> repositoryProduct;

        public HomeServices(IRepository<Product> repositoryProduct)
        {
            this.repositoryProduct = repositoryProduct;
        }

        public async Task<IEnumerable<Product>> Newest()
        {
            return await this.repositoryProduct.All()
                .OrderByDescending(x => x.Created_On)
                .Take(3)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> Trending()
        {
            return await this.repositoryProduct.All()
                .OrderByDescending(x => x.SellCount)
                .Take(3)
                .ToListAsync();
        }
    }
}