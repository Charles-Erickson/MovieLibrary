using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [DisplayName("Film Title")]
        public string Title { get; set; }
        [DisplayName("Film Genre")]
        public string Genre { get; set; }
        [DisplayName("Film Director")]
        public string DirectorName { get; set; }
    }
}