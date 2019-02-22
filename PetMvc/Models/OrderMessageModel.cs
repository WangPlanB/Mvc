using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class OrderMessageModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrdersId { get; set; }
        public int Num { get; set; }
        public double Price { get; set; }

        public virtual OrderModel Orders { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}