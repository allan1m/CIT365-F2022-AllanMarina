using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyScriptureJournal.Pages.Scriptures
{
    //The constructor uses dependency injection to add the RazorPagesMovieContext to the page:
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;

        //SearchString: Contains the text users enter in the search text box. SearchString has the
        //[BindProperty] attribute. [BindProperty] binds form values and query strings with the same
        //name as the property. [BindProperty(SupportsGet = true)] is required for binding on HTTP GET requests.
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        //Book: Contains the list of chpaters. Chapter allows the user to select a chapter from the list.
        //SelectList requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList? Book { get; set; }

        //Chapter: Contains the list of chpaters. Chapter allows the user to select a chapter from the list.
        //SelectList requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList? Chapter { get; set; }

        //Verse: Contains the list of verses. Verses allows the user to select a verse from the list.
        //SelectList requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList? Verse { get; set; }

        //BookBook: Contains the specific Book the user selects. For example, "".
        [BindProperty(SupportsGet = true)]
        public string? BookBook { get; set; }

        //BookChapter: Contains the specific chapter the user selects. For example, "".
        [BindProperty(SupportsGet = true)]
        public string? BookChapter { get; set; }

        //BookVerse: Contains the specific verse the user selects. For example, "".
        [BindProperty(SupportsGet = true)]
        public string? BookVerse { get; set; }

        //When a request is made for the page, the OnGetAsync method returns a list of scriptures to
        //the Razor Page. On a Razor Page, OnGetAsync or OnGet is called to initialize the state
        //of the page. In this case, OnGetAsync gets a list of scriptures and displays them.
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of chapters.
            //The following code is a LINQ query that retrieves all the chapters from the database.
            IQueryable<string> bookQuery = from l in _context.Scripture
                                              orderby l.Book
                                              select l.Book;

            // Use LINQ to get list of chapters.
            //The following code is a LINQ query that retrieves all the chapters from the database.
            IQueryable<string> chapterQuery = from n in _context.Scripture
                                            orderby n.Chapter
                                            select n.Chapter;

            // Use LINQ to get list of verses.
            //The following code is a LINQ query that retrieves all the verses from the database.
            IQueryable<string> verseQuery = from m in _context.Scripture
                                            orderby m.Verse
                                            select m.Verse;

            //The first line of the OnGetAsync method creates a LINQ query to select the scriptures:
            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                //The s => s.Title.Contains() code is a Lambda Expression.
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookBook))
            {
                scriptures = scriptures.Where(c => c.Book == BookBook);
            }

            if (!string.IsNullOrEmpty(BookChapter))
            {
                scriptures = scriptures.Where(a => a.Chapter == BookChapter);
            }

            if (!string.IsNullOrEmpty(BookVerse))
            {
                scriptures = scriptures.Where(x => x.Verse == BookVerse);
            }

            //The SelectList of chapters is created by projecting the distinct cahpters.
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());

            //The SelectList of chapters is created by projecting the distinct cahpters.
            Chapter = new SelectList(await chapterQuery.Distinct().ToListAsync());

            //The SelectList of verses is created by projecting the distinct verses.
            Verse = new SelectList(await verseQuery.Distinct().ToListAsync());

            Scripture = await scriptures.ToListAsync();
        }
    }
}
