using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rafa_Market.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Quantidade")]
        public float Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}