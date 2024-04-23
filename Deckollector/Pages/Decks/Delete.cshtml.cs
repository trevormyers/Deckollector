using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Decks
{
    public class DeleteModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public DeleteModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Deck Deck { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deck == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck.FirstOrDefaultAsync(m => m.DeckID == id);

            if (deck == null)
            {
                return NotFound();
            }
            else 
            {
                Deck = deck;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Deck == null)
            {
                return NotFound();
            }
            var deck = await _context.Deck.FindAsync(id);

            if (deck != null)
            {
                Deck = deck;
                _context.Deck.Remove(Deck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
