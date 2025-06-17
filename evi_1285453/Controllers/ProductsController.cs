using evi_1285453.Models;
using evi_1285453.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evi_1285453.Controllers
{
    public class ProductsController : Controller
    {
        ProductDbContext db = new ProductDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.OrderByDescending(p => p.PId).ToList();
            foreach (var product in products)
            {
                db.Entry(product).Collection(p => p.Details).Load();
                foreach (var detail in product.Details)
                {
                    db.Entry(detail).Reference(d => d.Color).Load();
                }
            }
            return View(products);
        }
        public ActionResult Create()
        {
            return PartialView("Create");
        }
        [HttpPost]
        public ActionResult Create(ProductVm productVm, int[] CId)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    PName = productVm.PName,
                    IsAviable = productVm.IsAviable,
                    Pdate = productVm.Pdate,
                    Price = productVm.Price,
                };
                HttpPostedFileBase file = productVm.ImageFile;
                if (file != null)
                {
                    string filename = Path.Combine("/Images/", DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(filename));
                    product.Image = filename;
                }
                foreach (var i in CId)
                {
                    var d = new Details()
                    {
                        Product = product,
                        PId = product.PId,
                        CId = i
                    };
                    db.Details.Add(d);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVm);
        }

        public ActionResult AddColor(int? id)
        {
            ViewBag.Color = new SelectList(db.Colors.ToList(), "CId", "CName", id ?? 0);
            return PartialView("AddColor");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var product = db.Products.Find(id);
            var details = db.Details.Where(e => e.PId == product.PId).ToList();
            var pobj = new ProductVm()
            {
                PId = product.PId,
                Details = details,
                Image = product.Image,
                IsAviable = product.IsAviable,
                Pdate = product.Pdate,
                PName = product.PName,
                Price = product.Price,
            };
            return PartialView("Edit", pobj);
        }
        [HttpPost]
        public ActionResult Edit(ProductVm productVm, int[] CId)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(productVm.PId);
                var details = db.Details.Where(e => e.PId == product.PId).ToList();
                product.PName = productVm.PName;
                product.IsAviable = productVm.IsAviable;
                product.Pdate = productVm.Pdate;
                product.Price = productVm.Price;

                HttpPostedFileBase file = productVm.ImageFile;
                if (file != null)
                {
                    string filename = Path.Combine("/Images/", DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName));
                    file.SaveAs(Server.MapPath(filename));
                    product.Image = filename;
                }
                else
                {
                    product.Image = product.Image;
                }
                db.Details.RemoveRange(details);
                foreach (var i in CId)
                {
                    var d = new Details()
                    {
                        Product = product,
                        PId = product.PId,
                        CId = i
                    };
                    db.Details.Add(d);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productVm);
        }
        public ActionResult Delete(int? id)
        {
            var product = db.Products.Find(id);
            var details = db.Details.Where(e => e.PId == product.PId).ToList();
            db.Details.RemoveRange(details);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}