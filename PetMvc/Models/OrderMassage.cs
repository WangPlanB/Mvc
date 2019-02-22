using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class OrderMassage
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int OrdersId { get; set; }
        public int Num { get; set; }
        public double Price { get; set; }

        public virtual OrderModel orders { get; set; }
        public virtual PetModel pets { get; set; }
    }
}