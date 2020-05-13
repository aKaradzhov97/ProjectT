namespace ProjectT.Services.Data.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public interface IProductsServices
    {
        Task<IEnumerable<ProductsInputViewModel>> GetAllProducts();

        Task<ProductsInputViewModel> CreateProduct(ProductsInputViewModel product);

        Task<Product> EditProduct(string id, ProductsInputViewModel product);

        Task<IEnumerable<Product>> DeleteProduct(string id);
    }
}