using Rafa_Market.Data;
using Rafa_Market.Helpers;
using Rafa_Market.Models;
using Rafa_Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rafa_Market.Controllers
{
    public class OrderController : Controller
    {
        private Rafa_MarketContext db = new Rafa_MarketContext(); 

        // GET: Order
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            orderView.Customer = new Models.Customer();
            orderView.Products = new List<ProductOrder>();

            Session["orderView"] = orderView;

            ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

            return View(orderView);
        }

        public ActionResult AddProduct()
        {
            ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;

            var ProductID = int.Parse(Request["ProductID"]);

            //Caso não haja produto escolhido
            if(ProductID == 0)
            {
                ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");
                ViewBag.Error = "Deve selecionar um produto";

                return View(productOrder);
            }

            //verifica se produto existe
            var Product = db.Products.Find(ProductID);
            if(Product == null)
            {
                ViewBag.ProductID = new SelectList(CombosHelper.GetProducts(), "ProductID", "Description");
                ViewBag.Error = "Produto não existe";

                return View(productOrder);
            }

            productOrder = orderView.Products.Find(p => p.ProductID == ProductID);

            if(productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Description = Product.Description,
                    Price = Product.Price,
                    ProductID = Product.ProductID,
                    Quantity = float.Parse(Request["Quantity"])
                };

                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }
            
            ViewBag.CustomerID = new SelectList(CombosHelper.GetCustomersNames(), "CustomerID", "Name");

            return View("NewOrder", orderView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}