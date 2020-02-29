using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HotelManager.Common;
using HotelManager.Data.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelManager.Areas.Identity.Pages.Account
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class RegisterModel : PageModel
    {
        private const string EmailConfirmationUrl = "/Account/ConfirmEmail";

        private readonly UserManager<User> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<User> userManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl = null) => ReturnUrl = returnUrl;

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (await userManager.FindByEmailAsync(Input.Email) != null)
            {
                ModelState.AddModelError(nameof(Input.Email), "User with the same email already exists!");
            }

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    Surname = Input.Surname,
                };

                IdentityResult result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    await userManager.AddToRoleAsync(user, GlobalConstants.UserRole);
                    return LocalRedirect(returnUrl);
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        public class InputModel
        {
            [StringLength(5, MinimumLength = 25)]
            [Required]
            public string FirstName { get; set; }

            public string FathersName { get; set; }

            public string Surname { get; set; }

            public string PersonalNumber { get; set; }

            public DateTime DateOfAppointment { get; set; }

            public bool ActiveOrNotActiveAccount { get; set; }

            public DateTime DateOfDismissal { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare(nameof(Password))]
            public string ConfirmPassword { get; set; }
        }
    }
}
