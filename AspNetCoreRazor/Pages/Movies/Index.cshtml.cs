using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRazor.Data;
using AspNetCoreRazor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreRazor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.AspNetCoreRazorContext _context;

        public IndexModel(AspNetCoreRazor.Data.AspNetCoreRazorContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(x => x.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}
