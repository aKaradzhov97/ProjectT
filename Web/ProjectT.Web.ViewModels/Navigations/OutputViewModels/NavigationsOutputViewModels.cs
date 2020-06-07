namespace ProjectT.Web.ViewModels.Navigations.OutputViewModels
{
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class NavigationsOutputViewModels : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}