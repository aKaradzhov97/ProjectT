namespace ProjectT.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ProjectT.Data.Models;

    public class SubCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.SubCategories.AnyAsync())
            {
                return;
            }

            var subCategories = new List<string>()
            {
                "T-Shirts",
                "Blouses",
                "Pullovers",
                "Jeans",
                "Shorts",
            };

            foreach (var category in dbContext.Categories)
            {
                foreach (var subCategory in subCategories)
                {
                    await dbContext.SubCategories.AddAsync(new SubCategory
                    {
                        Name = subCategory,
                        Created_On = DateTime.UtcNow,
                        Category = category,
                    });
                }
            }
        }
    }
}