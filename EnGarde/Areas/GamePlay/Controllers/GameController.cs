using Microsoft.AspNetCore.Mvc;

namespace EnGarde.Areas.GamePlay.Controllers
{
    [Area("GamePlay")]
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}