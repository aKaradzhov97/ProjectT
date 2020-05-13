namespace ProjectT.Web.ViewModels.Products.OutputViewModels
{
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ImagesOutputViewModel : IMapFrom<Image>
    {
        public string Url { get; set; }
    }
}