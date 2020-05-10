namespace ProjectT.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ProjectT.Services.Data.HomeServices;

    [ApiController]
    [Route("api/products")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices homeService;

        public HomeController(IHomeServices homeService)
        {
            this.homeService = homeService;
        }

        [Route("home")]
        public async Task<ActionResult> Get()
        {
            var newest = await this.homeService.Newest();
            var trending = await this.homeService.Trending();

            return this.Ok(new {Message = "Success", newest, trending});
        }
    }
}