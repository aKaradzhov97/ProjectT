namespace ProjectT.Services.Data.NavigationsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ProjectT.Data.Models;
    using ProjectT.Web.ViewModels.Navigations.OutputViewModels;

    public interface INavigationsServices
    {
        Task<IEnumerable<NavigationsOutputViewModels>> GetCategories();

        Task<IEnumerable<SubCategory>> GetSubCategories();
    }
}