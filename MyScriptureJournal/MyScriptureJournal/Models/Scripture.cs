using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        //The ID field is required by the database for the primary key
        public int ID { get; set; }

        //The [StringLength] attribute specifies the minimum and maximum character length allowed in this data field.
        //With this attribute:
        //The user is required to enter a miminum of 5 characters and maximum of 30 characters.
        //This data field will allow user to enter a book, e.g., The Bible, The Book of Mormon, etc.
        //The [RegularExpression] attribute specifies that a data field value in ASP.Net Dynamic Data must match the specified regular expression.
        //With this attribute:
        //The user is required to enter letters only.
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string Book { get; set; } = string.Empty;

        //The [StringLength] attribute specifies the minimum and maximum character length allowed in this data field.
        //With this attribute:
        //The user is required to enter a miminum of 3 characters and maximum of 20 characters.
        //This data field will allow user to enter a chapter, e.g., Genesis, 1 Nephi, etc.
        //The [RegularExpression] attribute specifies that a data field value in ASP.Net Dynamic Data must match the specified regular expression.
        //With this attribute:
        //The user is required to enter numbers and letters only.
        [RegularExpression(@"^[1-9]?[a-zA-Z\s]*$")]
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Chapter { get; set; } = string.Empty;

        //The [RegularExpression] attribute specifies that a data field value in ASP.Net Dynamic Data must match the specified regular expression.
        //With this attribute:
        //The user is required to enter two number values ranging from a minimum of 1 to 99.
        //The user is reqiured to enter a colon to discern between the two number values.
        //This data field will allow user to enter a numbered verse, e.g., 16:33, 4:6, 8:28, etc.
        [RegularExpression(@"[1-9][1-9]?:[1-9][1-9]?")]
        [StringLength(5)]
        [Required]
        public string Verse { get; set; } = string.Empty;

        //The [StringLength] attribute specifies the minimum and maximum character length allowed in this data field.
        //With this attribute:
        //The user is required to enter a miminum of 3 characters and maximum of 250 characters.
        //This data field will allow user to enter a their personal notes for a specific entry.
        //The [RegularExpression] attribute specifies that a data field value in ASP.Net Dynamic Data must match the specified regular expression.
        //With this attribute:
        //The user is required to enter letters only.
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        [StringLength(250, MinimumLength = 3)]
        [Required]
        public string Notes { get; set; } = string.Empty;

        //The [Display] attribute specifies the display name of a field. In the preceding code, "Date Added" instead of "DateAdded".
        //A [DataType] attribute that specifies the type of data in the DateAdded property. With this attribute:
        //The user isn't required to enter time information in the date field.
        //Only the date is displayed, not time information.
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
