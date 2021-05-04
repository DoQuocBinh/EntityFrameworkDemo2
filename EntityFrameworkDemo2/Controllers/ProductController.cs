using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkDemo2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo2.Controllers
{
    public class ProductController : Controller
    { 
        MVCDatabaseDemoContext dbContext = new MVCDatabaseDemoContext();
        public IActionResult Index()
        {          
            return View(dbContext.Products.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult DoCreate(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return View("Index", dbContext.Products.ToList());
        }
        public IActionResult Search(string txtSearch)
        {
            if(txtSearch == null || txtSearch.Length == 0)
            {
                return View("Index", dbContext.Products.ToList());
            }
            else
            {
                 var result =  dbContext.Products.Where(x => x.ProductName.Contains(txtSearch)).ToList();
                 return View("Index", result);
            }
          
        }
        public IActionResult Delete(int id)
        {
            var productToDelete = dbContext.Products.SingleOrDefault(x => x.ProductId == id);
            dbContext.Products.Remove(productToDelete);
            dbContext.SaveChanges();
            return View("Index", dbContext.Products.ToList());
        }
        public IActionResult Edit(int id)
        {
            var productToEdit = dbContext.Products.SingleOrDefault(x => x.ProductId == id);
            return View(productToEdit);
        }
        public IActionResult DoEdit(Product productToUpdate)
        {
            var productFromDB= dbContext.Products.SingleOrDefault(x => x.ProductId == productToUpdate.ProductId);
            productFromDB.ProductName = productToUpdate.ProductName;
            productFromDB.Price = productToUpdate.Price;
            dbContext.SaveChanges();
            //return View("Index", dbContext.Products.ToList());
            return RedirectToAction("Index");
        }
    }
}
