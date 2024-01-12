using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class AController : Controller
    {
        public string json2obj()
        {
            string json = obj2json();
            TCustomer customer = JsonSerializer.Deserialize<TCustomer>(json);
            return customer.FName + "/" + customer.FEmail;
        }
        public string obj2json()
        {
            TCustomer customer = new TCustomer()
            {
                FId = 1,
                FName = "Test",
                FPhone = "0912345678",
                FEmail = "0@gmail.com",
                FAddress = "Taipei",
                FPassword = "123"
            };
            string json = JsonSerializer.Serialize(customer);
            return json;
        }
        public IActionResult ShowCountBySession()
        {
            int count = 0;
            if (HttpContext.Session.Keys.Contains("Count"))
                count = (int)HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", count); 
            ViewBag.Count = count;
            return View();
        }
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
