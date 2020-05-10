namespace ProjectT.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ProjectT.Data.Models;
    using ProjectT.Services.Data.UserServices;
    using ProjectT.Web.ViewModels.Users;

    [ApiController]
    [Route("api/auth")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices usersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersServices usersService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [Route("login")]
        public async Task<ActionResult> Login(LoginInputViewModel login)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, login});
            }

            // Sign in
            var userLogin = await this.signInManager
                    .PasswordSignInAsync(login.Username, login.Password, true, false);

            if (!userLogin.Succeeded)
            {
                return this.BadRequest(new {Message = "Login failed", login});
            }

            var currentUser = await this.userManager.FindByNameAsync(login.Username);

            var user = await this.usersService.GetInfo(currentUser.UserName);

            return this.Ok(new {Message = "Login successful", user});
        }

        [Route("register")]
        public async Task<ActionResult> Register(RegisterInputViewModel register)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new {Message = "Ooopppsss! Something wrong!", this.ModelState, register});
            }

            if (await this.usersService.UsernameExists(register.Username))
            {
                return this.BadRequest(new {Message = "Username is already exists!", register});
            }

            if (await this.usersService.EmailExists(register.Email))
            {
                return this.BadRequest(new {Message = "Email is already exists!", register});
            }

            var user = new ApplicationUser
            {
                UserName = register.Username,
                Email = register.Email,
                PhoneNumber = register.Phone.ToString(),
                CreatedOn = DateTime.UtcNow,
            };

            var data = await this.userManager.CreateAsync(user, register.Password);

            if (!data.Succeeded)
            {
                return this.BadRequest(new {Message = "User  is NOT create!", register});
            }

            // SignInAsync is for auto sign in
            await this.signInManager.SignInAsync(user, false);
            return this.CreatedAtAction("Login", new {Message = "User is created!", register});
        }
    }
}