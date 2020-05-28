namespace ProjectT.Services.Data.ProductServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Web.ViewModels.Products.InputViewModels;
    using ProjectT.Web.ViewModels.Products.OutputViewModels;

    public interface IProductsServices
    {
        Task<IEnumerable<ProductsOutputViewModel>> GetAllProducts();

        Task<ProductsOutputViewModel> CreateProduct(ProductsInputViewModel product);

        Task<ProductsOutputViewModel> EditProduct(string id, ProductsInputViewModel product);

        Task<IEnumerable<ProductsOutputViewModel>> DeleteProduct(string id);

        Task<ICollection<ProductsOutputViewModel>> GetProductsByCategory();

        Task<ICollection<ProductsOutputViewModel>> GetProductsBySubCategory();
    }
}