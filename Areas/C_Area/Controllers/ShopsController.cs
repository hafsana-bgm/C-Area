using Microsoft.AspNetCore.Mvc;

namespace C_Area.Areas.C_Area.Controllers
{

    public class ShopsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
