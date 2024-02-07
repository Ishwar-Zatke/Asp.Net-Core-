using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;
using ModelBinding.Models;

namespace IActionResultExample.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isLoggedin?}")]
        //Url: /bookstore?bookid=5&isloggedin=true
        public IActionResult Index([FromRoute]int? bookid, [FromRoute]bool? isLoggedin,
           Book book)
        {
            //Book id should be applied
            if (bookid.HasValue == false)
            {
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied"); //-400
            }

            //Book id can't be less than or equal to 0
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be null or empty"); //-400
            }
            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000"); //- 404
            }


            //isloggedin should be true
            if (isLoggedin == false)
            {
                //return Unauthorized("User must be authenticated");
                return StatusCode(401);
            }
            return Content($"Book id: {bookid}", "text/plain");
        }
    }
}
