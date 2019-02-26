using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class PetType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int petTypeId { get; set; }
    }
}