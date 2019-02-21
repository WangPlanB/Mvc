using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class UserModel
    {
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string UsersPwd { get; set; }
        public string UPhone { get; set; }
        public string ULoc { get; set; }
        public string UAuthority { get; set; }
        //public virtual ICollection<Cart> Cart { get; set; }
        //public virtual OrderModel Orders { get; set; }
        //public virtual PetModel Pet { get; set; }
        //public virtual ICollection<Product> Product { get; set; }
    }
}