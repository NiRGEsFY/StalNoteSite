using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StalNoteSite.Models;

namespace StalNoteSite.Controllers
{
    public class TTKController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {

            TTKModel model = new TTKModel();
            model.caseItems = null;
            model.Bullets = null;

            using (var context = new Stalcraft2Context())
            {
                model.allWeaponItems = context.WeaponsItems.ToList();
                model.allArmorItems = context.ArmorsItems.ToList();
                model.Bullets = context.Bullets.ToList();
            }
            
            return View(model);
        }
    }
}
