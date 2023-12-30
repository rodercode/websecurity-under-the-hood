using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webSecurity_under_the_hood.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class Settings : PageModel
    {
        public void OnGet()
        {
        }
    }
}