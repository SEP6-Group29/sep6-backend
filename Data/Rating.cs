﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class Rating
    {
        [Key]
        public int movie_id { get; set; }
        public float rating { get; set; }
        public int votes { get; set; }
        //public int movie_id { get; set; }
        //public float rating { get; set; }
        //public string name { get; set; }
        //public string star_name { get; set; }
        //public string director_name { get; set; }
    }
}
