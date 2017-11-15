using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product obj)
        {
            ProductDB context = new ProductDB();
            Product p = new Product();
            p.ProductName = obj.ProductName;
            p.ProductDesc = obj.ProductDesc;
            p.ProductPrice = obj.ProductPrice;
            p.ProductQuantity = obj.ProductQuantity;

            context.Products.Add(p);
            context.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            ProductDB context = new ProductDB();
            Product p = new Product();
            if (Id != null)
            {
                var product = context.Products.Find(Id);
                context.Products.Remove(product);
            }
            context.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult GetList()
        {
            ProductDB context = new ProductDB();

            var list = context.Products.ToList(); 

            return Json(new { data = list },JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            ProductDB context = new ProductDB();
            var product = context.Products.Find(Id);
            var model = new ProductModel();
            model.ProductId = Id;
            model.ProductName = product.ProductName.ToString();
            model.ProductPrice = product.ProductPrice;
            model.ProductQuantity = product.ProductQuantity;
            model.ProductDesc = product.ProductDesc.ToString();
            return View("EditProduct",model); 
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel model)
        {
            ProductDB context = new ProductDB();
            var product = context.Products.Find(model.ProductId);
            product.ProductName = model.ProductName;
            product.ProductPrice = model.ProductPrice;
            product.ProductQuantity = model.ProductQuantity;
            product.ProductDesc = model.ProductDesc;
            context.SaveChanges();
            return View("Index");
        }


    }
}