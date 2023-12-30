using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webSecurity_under_the_hood.Pages.Account
{
    public class Login : PageModel
    {
        // binding the form data to the Credential object
        [BindProperty]
        public Credential Credential {get; set;} = new Credential();
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid) return Page();
            
            // Verify the credential
            if(Credential.UserName == "admin" && Credential.Password == "password")
            {
                // Creating the security context = principal
                var claims = new List<Claim> 
                {
                    new Claim(ClaimTypes.Name, Credential.UserName),
                    new Claim(ClaimTypes.Email, "admin@localhost"),
                    new Claim(ClaimTypes.Role, "HR"),
                };
                var primaryIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(primaryIdentity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = Credential.RememberMe,
                };

                // 1. serialize the principal into a string
                // 2. encrypt the string
                // 3. save that as a cookie in the http context
                await HttpContext.SignInAsync("MyCookieAuth", principal, authProperties);
                return (RedirectToPage("/Index"));
            }
            return Page();
        }
    }
    public class Credential
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName {get; set;} = string.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;} = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe {get; set;} = false;
    }
}