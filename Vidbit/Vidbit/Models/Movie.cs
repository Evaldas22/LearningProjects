using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidbit.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public short NumberInStock { get; set; }
        
        //this is called navigation property
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}