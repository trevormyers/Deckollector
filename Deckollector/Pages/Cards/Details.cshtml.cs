using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Cards
{
    public class DetailsModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public DetailsModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

      public Card Card { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.Decks)
                .Include(c => c.Wishlists)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (card == null)
            {
                return NotFound();
            }
            else 
            {
                Card = card;
            }
            return Page();
        }
    }
}
