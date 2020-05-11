namespace ProjectT.Services.Data.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Products;

    public interface IProductsServices
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<IEnumerable<Product>> CreateProduct(ProductsInputViewModel product);

        Task<IEnumerable<Image>> TakeProductImages(string id);

        Task<IEnumerable<Product>> DeleteProduct(string id);
    }
}