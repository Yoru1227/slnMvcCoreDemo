using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;

namespace prjMvcCoreDemo.Controllers
{
    public class CustomerController : SuperController
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            DbDemoContext db = new DbDemoContext();
            var data = from c in db.TCustomers select c;           
            if (string.IsNullOrEmpty(vm.txtKeyword))
                data = from p in db.TCustomers select p;
            else
                data = db.TCustomers.Where(p => p.FName.Contains(vm.txtKeyword) ||
                p.FPhone.Contains(vm.txtKeyword) ||
                p.FEmail.Contains(vm.txtKeyword) ||
                p.FAddress.Contains(vm.txtKeyword) ||
                p.FPassword.Contains(vm.txtKeyword));
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TCustomer c)
        {
            DbDemoContext db = new DbDemoContext();
            db.TCustomers.Add(c);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                DbDemoContext db = new DbDemoContext();
                TCustomer customer = db.TCustomers.FirstOrDefault(c => c.FId == id);
                if(customer != null)
                {
                    db.TCustomers.Remove(customer);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            DbDemoContext db = new DbDemoContext();
            TCustomer customer = db.TCustomers.FirstOrDefault(p => p.FId == id);
            if (customer == null)
                return RedirectToAction("List");
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(TCustomer cIn)
        {
            DbDemoContext db = new DbDemoContext();
            TCustomer customer = db.TCustomers.FirstOrDefault(c => c.FId == cIn.FId);
            if (customer != null)
            {
                customer.FName = cIn.FName;
                customer.FPhone = cIn.FPhone;
                customer.FEmail = cIn.FEmail;
                customer.FAddress = cIn.FAddress;              
                customer.FPassword = cIn.FPassword;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
