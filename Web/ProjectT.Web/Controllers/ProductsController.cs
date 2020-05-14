using System.Collections.Generic;
using ProjectT.CloudinaryHelper;

namespace ProjectT.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectT.Data.Models;
    using ProjectT.Services.Data.ProductServices;
    using ProjectT.Web.ViewModels.Products.InputViewModels;

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsServices productsServices;
        private readonly UserManager<ApplicationUser> userManager;

        public ProductsController(
            IProductsServices productsServices,
            UserManager<ApplicationUser> userManager)
        {
            this.productsServices = productsServices;
            this.userManager = userManager;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var data = await this.productsServices.GetAllProducts();

            return this.Ok(new {Message = "Successful", data});
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(ProductsInputViewModel product)
        {
            // ATTENTION That's call cloudinary
            // var result = await CloudinaryExtension.UploadAsync(Cloudinary cloudinary,ICollection<IFormFile> files);
            // FINISH WITH IMPORT FILE IN CLOUDINARY
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var data = await this.productsServices.CreateProduct(product);
            return this.Ok(new {Message = "Success!", data});
        }

        [HttpPut("edit/{id?}")]
        public async Task<ActionResult> Edit(string id, ProductsInputViewModel product)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var data = await this.productsServices.EditProduct(id, product);
            return this.Ok(new {Message = "Success!", data});
        }

        [HttpDelete("delete/{id?}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var data = await this.productsServices.DeleteProduct(id);
            return this.CreatedAtAction("GetAll", new {Message = "Success!", data});
        }
    }
}