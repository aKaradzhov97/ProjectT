namespace ProjectT.Services.Data.CategoryServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;

    public interface INavigationsServices
    {
        Task<ICollection<Category>> GetCategories();

        Task<ICollection<SubCategory>> GetSubCategories();
    }
}