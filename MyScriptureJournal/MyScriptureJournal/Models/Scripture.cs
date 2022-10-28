using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        //The ID field is required by the database for the primary key
        public int ID { get; set; }
        public string Book { get; set; } = string.Empty;
        public string Verse { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        //The [Display] attribute specifies the display name of a field. In the preceding code, "Date Added" instead of "DateAdded".
        //A [DataType] attribute that specifies the type of data in the ReleaseDate property. With this attribute:
        //The user isn't required to enter time information in the date field.
        //Only the date is displayed, not time information.
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
