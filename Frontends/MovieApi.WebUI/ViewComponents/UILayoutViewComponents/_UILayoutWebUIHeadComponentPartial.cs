using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutWebUIHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
