using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class Movie
    {
       
        public int id { get; set; }
        public string title { get; set; } = null!;
        public decimal year { get; set; }
        public List<Directors> directors { get; set; } = new List<Directors>();
        public List<Star> stars { get; set; } = new List<Star>();
        public Rating rating { get; set; }
}
        //public int movie_id { get; set; }
        //public float rating { get; set; }
        //public string name { get; set; }
        //public string star_name { get; set; }
        //public string director_name { get; set; }
    }

