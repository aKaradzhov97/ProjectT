namespace ProjectT.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectT.Data.Models;
    using ProjectT.Services.Data.HomeServices;
    using ProjectT.Services.Data.UserServices;

    [ApiController]
    [Route("api/products")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices homeService;
        private readonly IUsersServices usersServices;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IHomeServices homeService,
            IUsersServices usersServices,
            UserManager<ApplicationUser> userManager)
        {
            this.homeService = homeService;
            this.usersServices = usersServices;
            this.userManager = userManager;
        }

        [Route("home")]
        public async Task<ActionResult> Get()
        {
            var newest = await this.homeService.Newest();
            var trending = await this.homeService.Trending();

            var data = new Dictionary<string, IEnumerable>();
            data["newest"] = newest;
            data["trending"] = trending;

            var currentUser = await this.userManager.GetUserAsync(this.User);

            if (currentUser == null)
            {
                return this.Ok(new {Message = "Success", data});
            }

            var user = await this.usersServices.GetInfo(currentUser.UserName);

            return this.Ok(new {Message = "Success", data, user});
        }
    }
}