namespace ProjectT.Services.Data.HomeServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;
    using ProjectT.Web.ViewModels.Products.OutputViewModels;

    public interface IHomeServices
    {
            Task<IEnumerable<ProductsOutputViewModel>> Newest();

            Task<IEnumerable<ProductsOutputViewModel>> Trending();
    }
}