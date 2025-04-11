using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> MovieList()
        {
            TempData["v1"] = "Film Listesi";
            TempData["v2"] = "Tüm Filmler";
            return View();
        }
    }
}
