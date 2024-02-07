using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("register")]
    //Bind avoid overposting
    // public IActionResult Index([Bind(nameof(Person.PersonName), "Email", nameof(Person.Password),nameof(Person.ConfirmPassword))] Person person)
    // Instead of Bind provide FromBody to get data from body
    public IActionResult Index(Person person)
    {
      if (!ModelState.IsValid)
      {
        string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
  
        return BadRequest(errors);
      }

      return Content($"{person}");
    }
  }
}
