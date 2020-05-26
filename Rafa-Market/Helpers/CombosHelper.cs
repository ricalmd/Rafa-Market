using Rafa_Market.Data;
using Rafa_Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafa_Market.Helpers
{
    public class CombosHelper:IDisposable
    {
        private static Rafa_MarketContext db = new Rafa_MarketContext();

        public static List<DocumentType> GetDocumentTypes()
        {
            var DocumentTypes = db.DocumentTypes.ToList();
            DocumentTypes.Add(new DocumentType
            {
                DocumentTypeID = 0,
                Description = "[Selecione um tipo de documento...]"
            });

            return DocumentTypes.OrderBy(d => d.Description).ToList();
        }

        public static List<Customer> GetCustomersNames()
        {
            var Customers = db.Customers.ToList();
            Customers.Add(new Customer 
            {
                CustomerID = 0, 
                FirstName = "[Selecione um cliente]" 
            });

            return Customers.OrderBy(c => c.Name).ToList();
        }

        public static List<Product> GetProducts()
        {
            var Products = db.Products.ToList();
            Products.Add(new Product
            {
                ProductID = 0,
                Description = "[Selecione um produto...]"
            });

            return Products.OrderBy(p => p.Description).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}