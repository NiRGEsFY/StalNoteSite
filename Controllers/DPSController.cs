using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StalNoteSite.Analize.Models;

namespace StalNoteSite.Controllers
{
    public class DPSController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {

            TTKModel model = new TTKModel();
            model.caseItems = null;
            model.Bullets = null;

            using (var context = new ApplicationDbContext())
            {
                model.allWeaponItems = context.WeaponsItems.ToList();
                model.allArmorItems = context.ArmorsItems.ToList();
                model.Bullets = context.Bullets.ToList();
            }

            return View(model);
        }
    }
}
