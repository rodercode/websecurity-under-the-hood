using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webSecurity_under_the_hood.Pages.Shared
{
    public class _LoginStatusPartial : PageModel
    {
        private readonly ILogger<_LoginStatusPartial> _logger;

        public _LoginStatusPartial(ILogger<_LoginStatusPartial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}