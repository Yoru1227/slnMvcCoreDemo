using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List(CKeywordViewModel vm)
        {
            DbDemoContext db = new DbDemoContext();
            var data = from p in db.TProducts select p;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                data = from p in db.TProducts select p;
            else
                data = db.TProducts.Where(p => p.FName.Contains(vm.txtKeyword));

            return View(data);
        }
        public ActionResult Edit(int? id)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct product = db.TProducts.FirstOrDefault(p => p.FId == id);
            if (product == null)
                return RedirectToAction("List");
            CProductWrap cp = new CProductWrap();
            cp.product = product;
            return View(cp);
        }
        [HttpPost]
        public ActionResult Edit(CProductWrap pIn)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct product = db.TProducts.FirstOrDefault(p => p.FId == pIn.FId);
            if (product != null)
            {
                //if (pIn.photo != null)
                //{
                //    string photoName = Guid.NewGuid().ToString() + ".jpg";
                //    product.fImagePath = photoName;
                //    pIn.photo.SaveAs(Server.MapPath("..\\..\\images") + "\\" + photoName);
                //}
                product.FName = pIn.FName;
                product.FQty = pIn.FQty;
                product.FCost = pIn.FCost;
                product.FPrice = pIn.FPrice;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TProduct p)
        {
            DbDemoContext db = new DbDemoContext();
            db.TProducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct product = db.TProducts.FirstOrDefault(p => p.FId == id);
            if (product != null)
            {
                db.TProducts.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public ActionResult Index()
        {
            return View();
        }
    }

}

