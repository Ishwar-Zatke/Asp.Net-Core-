using Microsoft.AspNetCore.Mvc;

namespace ViewComponentEg.ViewComponents
{
    
    public class GridViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return ViewComponent();
        }
    }
}
