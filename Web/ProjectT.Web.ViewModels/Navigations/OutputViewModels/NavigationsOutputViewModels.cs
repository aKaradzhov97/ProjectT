namespace ProjectT.Web.ViewModels.Navigations.OutputViewModels
{
    using System.Collections.Generic;

    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class NavigationsOutputViewModels : IMapFrom<Category>
    {
        public string Name { get; set; }
        
        public virtual ICollection<NavigationSubCategoryOutputViewModels> SubCategories { get; set; }
    }
}