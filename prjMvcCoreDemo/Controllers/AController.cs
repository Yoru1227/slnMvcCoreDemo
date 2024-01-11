using Microsoft.AspNetCore.Mvc;

namespace prjMvcCoreDemo.Controllers
{
    public class AController : Controller
    {
        public string SayHello()
        {
            return "雞你太美";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
