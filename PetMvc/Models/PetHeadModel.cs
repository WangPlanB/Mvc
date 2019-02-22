using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class PetHeadModel
    {
        public int PetHeadId { get; set; }
        public string PetHeadPath { get; set; }
        public int PetId { get; set; }

        public virtual PetModel Pet { get; set; }
    }
}