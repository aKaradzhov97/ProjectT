namespace ProjectT.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;

    public interface IHomeServices
    {
            Task<IEnumerable<Product>> Newest();

            Task<IEnumerable<Product>> Trending();
    }
}