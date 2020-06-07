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
            var categories = await this.navigationsServices.GetCategories();
            var subCategories = await this.navigationsServices.GetSubCategories();

            var data = new Dictionary<string, IEnumerable>();
            data["categories"] = categories;
            data["subCategories"] = subCategories;

            return this.Json(data);
            //return this.Ok(new {Message = "Successfully loaded!", data});
        }
    }
}