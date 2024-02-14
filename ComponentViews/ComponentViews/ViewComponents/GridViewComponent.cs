using Microsoft.AspNetCore.Mvc;
namespace ComponentViews.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult>  InvokeAsync()
        {
            ViewData["CustomData"] = "Custom VIew Data passing through partial View";
            return View();//partial view a shared wih viewcomponent name ie Grid/Default.cshtml
        }
    }
}
