using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Productdescribe { get; set; }
        public double ProductPrice { get; set; }
        public int ProductInventory { get; set; }
        public int ProductState { get; set; }
        public int UsersId { get; set; }
        public virtual ICollection<OrderModel> OrderMassage { get; set; }
        public virtual UserModel Users { get; set; }
        public virtual ICollection<ProductHeadModel> ProductHead { get; set; }
    }
}