namespace ProjectT.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ProjectT.Services.Data.NavigationsServices;

    [ApiController]
    [Route("api/navigation")]
    public class NavigationController : Controller
    {
        private readonly INavigationsServices navigationsServices;

        public NavigationController(INavigationsServices navigationsServices)
        {
            this.navigationsServices = navigationsServices;
        }

        public async Task<ActionResult> MainCategory()
        {
            var data = await this.navigationsServices.GetCategories();

            return this.Ok(new {Message = "Successfully loaded!", data});
        }
    }
}