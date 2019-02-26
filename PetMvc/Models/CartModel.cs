using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductHeadPath { get; set; }
        public double ProductPrice { get; set; }
        public int Number { get; set; }
        public double Pay { get; set; }
        public int UsersId { get; set; }

        public  UsersModel Users { get; set; }
    }
}