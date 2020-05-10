using ProjectT.Web.ViewModels.Products;

namespace ProjectT.Services.Data.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;

    public interface IProductsServices
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<IEnumerable<Product>> CreateProduct(ProductsInputViewModel product);
    }
}