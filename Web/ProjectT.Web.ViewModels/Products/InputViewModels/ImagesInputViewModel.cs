namespace ProjectT.Web.ViewModels.Products.InputViewModels
{
    using ProjectT.Data.Models;
    using ProjectT.Services.Mapping;

    public class ImagesInputViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string ProductId { get; set; }
    }
}