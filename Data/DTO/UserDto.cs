using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class UserDto
    {
       

        public string username { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }

    }
}
