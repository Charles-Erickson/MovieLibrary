using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class Movies
    {
        [DisplayName("Film Title")]
        public string Title { get; set; }
        [DisplayName("Film Genre")]
        public string Genre { get; set; }
        [DisplayName("Film Director")]
        public string Director { get; set; }
    }
}