namespace ProjectT.Web.Controllers
{
    using System;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.WebUtilities;
    using ProjectT.Data.Models;
    using ProjectT.Services.Data.UserServices;
    using ProjectT.Services.Messaging;
    using ProjectT.Web.ViewModels.Users.InputViewModels;
    using ProjectT.Web.ViewModels.Users.OutputViewModels;

    [ApiController]
    [Route("api/auth")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices usersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailSender emailSender;

        public UsersController(
            IUsersServices usersService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            this.usersService = usersService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }

        [HttpPost("login")]
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
                return this.BadRequest(new {Message = "Login failed!", login});
            }

            var currentUser = await this.userManager.FindByNameAsync(login.Username);

            var user = await this.usersService.GetInfo(currentUser.UserName);

            return this.Ok(new {Message = "Login successful!", user});
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.Ok(new {Message = "Logout successful!"});
        }

        [HttpPost("register")]
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

            var newUser = new ApplicationUser
            {
                UserName = register.Username,
                Email = register.Email,
                PhoneNumber = register.Phone.ToString(),
                CreatedOn = DateTime.UtcNow,
            };

            var data = await this.userManager.CreateAsync(newUser, register.Password);

            var user = new UserViewModel
            {
                Username = register.Username,
                Email = register.Email,
                Phone = register.Phone,
            };

            if (!data.Succeeded)
            {
                return this.BadRequest(new {Message = "User  is NOT create!", register});
            }

            // SignInAsync is for auto sign in
            // await this.signInManager.SignInAsync(user, false);

            return this.CreatedAtAction("Login", new {Message = "User is created!", user});
        }

        [HttpPost("forgotpassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordEmailInputViewModel email)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.FindByEmailAsync(email.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return this.BadRequest(new {Message = "User not found!"});
                }

                var code = await this.userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackUrl = this.Url.Action(
                    "resetpassword",
                    "users",
                    new {code = code},
                    protocol: this.Request.Scheme);

                var message = new Message(new string[] {email.Email},
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                this.emailSender.SendEmailAsync(message);


                //  $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."

                return this.Ok(new {Message = "Forgot password successful! Sending reset code!"});
            }

            return this.BadRequest(new {Message = "Ooopppsss! Something wrong!"});
        }

        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordInputViewModel reset)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Ooopppsss! Something wrong!");
            }

            var user = await this.userManager.FindByEmailAsync(reset.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return this.RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await this.userManager.ResetPasswordAsync(user, reset.Code, reset.Password);
            if (result.Succeeded)
            {
                return this.RedirectToPage("./ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.Ok();
        }
    }
}