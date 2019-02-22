using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class PetModel
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetStartTime { get; set; }
        public string PetInType { get; set; }
        public string PetType { get; set; }
        public int PetInventory { get; set; }
        public string PetBodily { get; set; }
        public string PetHead { get; set; }
        public double PetPrice { get; set; }
        public int PetState { get; set; }
        public int UsersId { get; set; }

        public virtual UserModel Users { get; set; }
    }
}