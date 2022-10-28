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
                        Book = "When Harry Met Sally",
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Verse = "Romantic Comedy",
                        Notes = "I love this verse"
                    },

                    new Scripture
                    {
                        Book = "Ghostbusters ",
                        DateAdded = DateTime.Parse("1984-3-13"),
                        Verse = "Comedy",
                        Notes = "I love this verse"
                    },

                    new Scripture
                    {
                        Book = "Ghostbusters 2",
                        DateAdded = DateTime.Parse("1986-2-23"),
                        Verse = "Comedy",
                        Notes = "I love this verse"
                    },

                    new Scripture
                    {
                        Book = "Rio Bravo",
                        DateAdded = DateTime.Parse("1959-4-15"),
                        Verse = "Western",
                        Notes = "I love this verse"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}