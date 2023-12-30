using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webSecurity_under_the_hood.Pages;
    
    // This page requires the user to be authenticated
    [Authorize]
    public class IndexModel : PageModel
    {
    public void OnGet()
    {

    }
}
