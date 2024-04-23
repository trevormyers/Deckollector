using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Collections
{
    public class DetailsModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public DetailsModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

      public Collection Collection { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Collection == null)
            {
                return NotFound();
            }

            var collection = await _context.Collection.FirstOrDefaultAsync(m => m.CollectionID == id);
            if (collection == null)
            {
                return NotFound();
            }
            else 
            {
                Collection = collection;
            }
            return Page();
        }
    }
}
