using System.ComponentModel.DataAnnotations;

namespace Rafa_Market.Models
{
    public class ProductOrder : Product
    {
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Quantidade")]
        public float Quantity { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Valor")]
        public decimal Value { get { return Price * (decimal)Quantity; } }
    }
}