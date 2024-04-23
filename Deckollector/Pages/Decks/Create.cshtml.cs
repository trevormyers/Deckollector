using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Deckollector.Data;
using Deckollector.Models;

namespace Deckollector.Pages.Decks
{
    public class CreateModel : CollectionNamePageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public CreateModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCollectionsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Deck Deck { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Deck == null || Deck == null)
            {
                return Page();
            }

            _context.Deck.Add(Deck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
