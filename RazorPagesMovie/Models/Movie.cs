using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        /*
         * The [Display] attribute specifies the display name of a field. 
         * In the preceding code, "Release Date" instead of "ReleaseDate".
         */
        [Display(Name = "Release Date")]
        /*
         * The [DataType] attribute specifies the type of the data (Date). 
         * The time information stored in the field isn't displayed.
         */
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        /*
         * The [Column(TypeName = "decimal(18, 2)")] data annotation enables 
         * Entity Framework Core to correctly map Price to currency in the 
         * database
         */
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}