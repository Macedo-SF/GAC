using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace GAC.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("pt-BR"));
            ViewData["TimeStamp"] = dateTime;
        }
    }
}