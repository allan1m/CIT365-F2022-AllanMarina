using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        //The [Required] and [MinimumLength] attributes indicate that a
        //property must have a value. Nothing prevents a user from entering
        //white space to satisfy this validation.
        //The[StringLength] attribute can set a maximum length of a string property, and
        //optionally its minimum length.
        [StringLength(60, MinimumLength = 3)]
        [Required]
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        //The [RegularExpression] attribute is used to limit what characters
        //can be input. In the preceding code, Genre:
        //* Must only use letters.
        //* The first letter is required to be uppercase.
        //White spaces are allowed while numbers, and special characters are not allowed.
        //The[StringLength] attribute can set a maximum length of a string property, and
        //optionally its minimum length.
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        //The [Range] attribute constrains a value to within a specified range.
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        /*
         * The [Column(TypeName = "decimal(18, 2)")] data annotation enables 
         * Entity Framework Core to correctly map Price to currency in the 
         * database
         */
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        //The RegularExpression Rating:
        //* Requires that the first character be an uppercase letter.
        //* Allows special characters and numbers in subsequent spaces. "PG-13" is
        //valid for a rating, but fails for a Genre.
        //The [StringLength] attribute can set a maximum length of a string
        //property, and optionally its minimum length.
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}