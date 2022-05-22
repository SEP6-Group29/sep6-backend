using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal year { get; set; }       
        public int movie_id { get; set; }
        public float rating { get; set; }
        public string star_name { get; set; }
        public string director_name { get; set; }
    }
}
