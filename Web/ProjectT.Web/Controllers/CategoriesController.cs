namespace ProjectT.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            
        }

        public async Task<ActionResult> MainCategory()
        {
            return this.Ok();
        }
    }
}