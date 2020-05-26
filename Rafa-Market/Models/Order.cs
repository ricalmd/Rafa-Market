﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rafa_Market.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime DataOrder { get; set; }

        public int CustomerID { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}