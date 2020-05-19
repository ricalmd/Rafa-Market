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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}