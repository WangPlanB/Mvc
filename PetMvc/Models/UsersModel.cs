using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMvc.Models
{
    public class UsersModel
    {
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string UsersPwd { get; set; }
        public string UPhone { get; set; }
        public string ULoc { get; set; }
        public int UAuthority { get; set; }
    }
}