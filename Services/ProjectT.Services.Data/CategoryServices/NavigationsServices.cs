namespace ProjectT.Services.Data.CategoryServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Common.Repositories;
    using ProjectT.Data.Models;

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


        public async Task<ICollection<Category>> GetCategories()
        {
            var categories = await this.repositoryCategory.All().ToListAsync();

            return categories;
        }

        public async Task<ICollection<SubCategory>> GetSubCategories()
        {
            var subCategories = await this.repositorySubCategory.All().ToListAsync();

            return subCategories;
        }
    }
}