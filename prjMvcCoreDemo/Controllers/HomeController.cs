using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace prjMvcCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(CLoginViewModel vm)
        {
            TCustomer c = new DbDemoContext().TCustomers.
                FirstOrDefault(c => c.FEmail == vm.txtAccount);
            if (c != null && c.FPassword.Equals(vm.txtPassword))
            {                
                string json = JsonSerializer.Serialize(c);
                HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index()
        {
            string json = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER);
            TCustomer c = JsonSerializer.Deserialize<TCustomer>(json);
            if (c == null)
                return RedirectToAction("Login");
            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
