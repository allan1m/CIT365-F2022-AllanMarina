using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                if (context == null || context.Scripture == null)
                {
                    throw new ArgumentNullException("Null MyScriptureJournalContext");
                }

                //If there are any scriptures in the database, the seed initializer returns and no scriptures are added.
                // Look for any Scriptures.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "The Bible",
                        Chapter = "Genesis",
                        Verse = "God created the heavens and the earth.",
                        Notes = "This is the beginning of the bible"
                    },

                    new Scripture
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "The Book of Mormon",
                        Chapter = "1 Nephi",
                        Verse = "Nephi begins the record of his people",
                        Notes = "This is the beginning of the the book of mormon"
                    },

                    new Scripture
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "The Book of Mormon",
                        Chapter = "1 Nephi",
                        Verse = "Lehi takes his family into the wilderness by the Red Sea",
                        Notes = "Second chapter"
                    },

                    new Scripture
                    {
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "The Book of Mormon",
                        Chapter = "1 Nephi",
                        Verse = "Lehi's sons return to Jerusalem to obtain the plates of brass",
                        Notes = "Third chapter"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}