using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()         //Added a View to Index using Scaffolding,List Template and Product model.
        {

            List<Product> products = context.Collection().ToList();
            
            //In above line we can see context.Collection. This Collection() is a property of IQueryable. That's why we have used IQueryable in line 69 of MyShop\MyShop.DataAccess.InMemory\ProductRepository.cs

            return View(products);
        }
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                context.Insert(p);
                context.Commit();
                return RedirectToAction("Index");

            }
        }
        public ActionResult Edit(string id)
        {
            Product p = context.Find(id);
            if (p == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(p);
            }
        }
        
        [HttpPost]
        public ActionResult Edit(Product p, string id)
        {
            Product productToEdit = context.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(p);
                }
                productToEdit.Category = p.Category;
                productToEdit.Description = p.Description;
                productToEdit.Id = p.Id;
                productToEdit.Image = p.Image;
                productToEdit.Name = p.Name;
                productToEdit.Price = p.Price;

                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}