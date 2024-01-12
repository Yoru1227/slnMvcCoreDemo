using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class ShoppingController : SuperController
    {
        public IActionResult List()
        {
            //string keyword = Request.Form["txtKeyword"];
            DbDemoContext db = new DbDemoContext();
            var data = from p in db.TProducts select p;
            return View(data);
        }
        public IActionResult AddToCart(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            ViewBag.FID = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(CAddToCartViewModel vm)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct product = db.TProducts.FirstOrDefault(p => p.FId == vm.txtFId);
            if (product != null)
            {
                string json = "";
                List<CShoppingCartItem> cart = null;
                if (HttpContext.Session.Keys.Contains(CDictionary.SK_UNPURCHASED_PRODUCT_LIST))
                {
                    json = HttpContext.Session.GetString(CDictionary.SK_UNPURCHASED_PRODUCT_LIST);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
                }
                else
                    cart = new List<CShoppingCartItem>();
                CShoppingCartItem item = new CShoppingCartItem();
                item.price = (decimal)product.FPrice;
                item.productId = vm.txtFId;
                item.count = vm.txtCount;
                item.product = product;
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_UNPURCHASED_PRODUCT_LIST, json);
            }
            return RedirectToAction("List");
        }
        public IActionResult CartView()
        {
            string json = "";
            List<CShoppingCartItem> cart = null;
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_UNPURCHASED_PRODUCT_LIST))
            {
                json = HttpContext.Session.GetString(CDictionary.SK_UNPURCHASED_PRODUCT_LIST);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            }
            if (cart == null)
                return RedirectToAction("List");
            return View(cart);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
