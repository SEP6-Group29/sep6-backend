using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class FilterMovie
    {
        //filter, home page first 5
        public int id { get; set; }
        
        public string title { get; set; } = null!;
        public decimal year { get; set; }

    }
}
