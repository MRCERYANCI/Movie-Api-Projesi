using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutWebUINavBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
