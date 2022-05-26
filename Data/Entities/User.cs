using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class User
    {
        public int id { get; set; }

        public string username { get; set; } 
        [JsonIgnore] 
        public string password { get; set; }
        public string emailAddress { get; set; }
      
    }
}
