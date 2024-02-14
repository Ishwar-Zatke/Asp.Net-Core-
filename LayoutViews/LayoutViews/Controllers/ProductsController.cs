using Microsoft.AspNetCore.Mvc;

namespace LayoutViews.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-products/{ProductId}")]
        public IActionResult Search(int? ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }

        [Route("order-products")]
        public IActionResult Order()
        {
            return View();
        }

    }
}
