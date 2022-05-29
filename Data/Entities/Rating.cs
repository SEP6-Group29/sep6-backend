using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class Rating
    {
        
        public int movie_id { get; set; }
        public float value { get; set; }
        public int votes { get; set; }
        public virtual Movie movies { get; set; } = null!;
        //public virtual FilterMovie movies_ { get; set; } = null!;
        //public int movie_id { get; set; }
        //public float rating { get; set; }
        //public string name { get; set; }
        //public string star_name { get; set; }
        //public string director_name { get; set; }
    }
}
