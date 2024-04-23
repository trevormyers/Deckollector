using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Cards
{
    public class CreateModel : DeckNamePageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public CreateModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDecksDropDownList(_context);
            PopulateWishlistsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Card Card { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Card == null || Card == null)
            {
                return Page();
            }

            _context.Card.Add(Card);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
