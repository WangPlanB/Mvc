using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string OrderNum { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public int State { get; set; }
    }
}