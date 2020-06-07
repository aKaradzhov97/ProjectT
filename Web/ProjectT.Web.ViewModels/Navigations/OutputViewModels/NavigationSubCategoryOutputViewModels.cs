namespace ProjectT.Web.ViewModels.Navigations.OutputViewModels
{
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class NavigationSubCategoryOutputViewModels : IMapFrom<SubCategory>
    {
        public string Name { get; set; }
    }
}