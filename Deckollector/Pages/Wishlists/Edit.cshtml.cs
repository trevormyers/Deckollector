using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Wishlists
{
    public class EditModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public EditModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wishlist Wishlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist =  await _context.Wishlist.FirstOrDefaultAsync(m => m.WishlistID == id);
            if (wishlist == null)
            {
                return NotFound();
            }
            Wishlist = wishlist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(Wishlist.WishlistID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WishlistExists(int id)
        {
          return (_context.Wishlist?.Any(e => e.WishlistID == id)).GetValueOrDefault();
        }
    }
}
