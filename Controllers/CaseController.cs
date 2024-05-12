using Microsoft.AspNetCore.Mvc;

namespace StalNoteSite.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
