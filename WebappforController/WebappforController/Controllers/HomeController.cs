using Microsoft.AspNetCore.Mvc;
using WebappforController.Models;
namespace WebappforController.Controllers
{
    [Controller]
    public class HomeController: Controller
    {
        //Attribute Routing
        [Route("/sayhello")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult(){
            //    Content = "Hello from Index", ContentType = "text/plain"
            //};
            return Content("Hello from Index", "text/plain");
        }

        [Route("/person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };
            //return "{\"key\":\"value\" }";
            return new JsonResult(person);
        }
    }
}
