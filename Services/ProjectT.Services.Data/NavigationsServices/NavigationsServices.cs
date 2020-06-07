namespace ProjectT.Services.Data.NavigationsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;
    using ProjectT.Web.ViewModels.Navigations.OutputViewModels;

    public class NavigationsServices : INavigationsServices
    {
        private readonly IRepository<Category> repositoryCategory;
        private readonly IRepository<SubCategory> repositorySubCategory;

        public NavigationsServices(
            IRepository<Category> repositoryCategory,
            IRepository<SubCategory> repositorySubCategory)
        {
            this.repositoryCategory = repositoryCategory;
            this.repositorySubCategory = repositorySubCategory;
        }


        public async Task<IEnumerable<NavigationsOutputViewModels>> GetCategories()
        {
            var categories = await this.repositoryCategory.All().To<NavigationsOutputViewModels>().ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            var subCategories = await this.repositorySubCategory.All().ToListAsync();

            return subCategories;
        }
    }
}