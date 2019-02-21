using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class OrderModel
    {
        public int OrdersId { get; set; }
        public double Pay { get; set; }
        public DateTime Time { get; set; }
        public int State { get; set; }
        public int UsersId { get; set; }
        public virtual ICollection<OrderModel> OrderMassage { get; set; }
        public virtual UserModel Users { get; set; }
    }
}