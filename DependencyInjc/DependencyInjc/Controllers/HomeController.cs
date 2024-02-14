using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

namespace DependencyInjc.Controllers
{
    public class HomeController : Controller
    {
        //Reference variable for city service
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
        }

        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService _citiesService)
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            //using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            //{
            //    //Injecting city service
            //    scope.ServiceProvider.GetService<ICitiesService>();

            //    ViewBag.InstanceId_CitiesService_Inscope = _citiesService1.ServiceInstanceId;
            //}
            return View(cities);
        }
    }
}
