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
        public int PetInventory { get; set; }
        public string PetBodily { get; set; }
        public double PetPrice { get; set; }
        public int PetState { get; set; }
        public string PetHead { get; set; }
        public int Pid { get; set; }
        public int TypeId { get; set; }
        public PetType petTypes { get; set; }
    }
}