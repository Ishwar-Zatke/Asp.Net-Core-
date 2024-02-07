using Microsoft.AspNetCore.Mvc;

namespace VIews.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View(); //Index.cshtml
            //return View("abc");
            //return new ViewResult() {  ViewName = "abc" };
        }
    }
}
