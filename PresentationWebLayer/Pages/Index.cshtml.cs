using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PresentationWebLayer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string hostname = "https://localhost:44347";
            var web = new WebClient();
            var url = $"{hostname}/api/Validata/GetAll";
            var responseString = web.DownloadString(url);
            TempData["data"] = responseString;

        }
    }
}
