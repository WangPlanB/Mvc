using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class ProductHeadModel
    {
        public int ProductHeadId { get; set; }
        public string ProductHeadPath { get; set; }
        public int ProductId { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}