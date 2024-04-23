using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Wishlists
{
    public class DetailsModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public DetailsModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

      public Wishlist Wishlist { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.FirstOrDefaultAsync(m => m.WishlistID == id);
            if (wishlist == null)
            {
                return NotFound();
            }
            else 
            {
                Wishlist = wishlist;
            }
            return Page();
        }
    }
}
