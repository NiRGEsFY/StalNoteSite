using Microsoft.AspNetCore.Mvc;
using StalNoteSite.Data.AuctionItem;
using StalNoteSite.Models;
using System.Diagnostics;

namespace StalNoteSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;


        }

        public IActionResult Index()
        {
            List<SelledItem> items;
            using (var context = new Stalcraft2Context())
            {
                items = context.SelledItems.Take(5).ToList();
            }
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
