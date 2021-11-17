using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace user_test.Data
{
    //[Table("Client")]
    public class User
    {        
        public int id { get; set; }         
        public string name { get; set; }         
        public string email { get; set; }
        public string password { get; set; }
    }
}
