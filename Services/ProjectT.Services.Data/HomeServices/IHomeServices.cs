namespace ProjectT.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public interface IHomeServices
    {
            Task<IEnumerable<ProductsInputViewModel>> Newest();

            Task<IEnumerable<ProductsInputViewModel>> Trending();
    }
}