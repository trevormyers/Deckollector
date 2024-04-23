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

namespace Deckollector.Pages.Decks
{
    public class EditModel : CollectionNamePageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public EditModel(Deckollector.Data.DeckollectorContext context)
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

            var deck =  await _context.Deck.FirstOrDefaultAsync(m => m.DeckID == id);
            if (deck == null)
            {
                return NotFound();
            }
            Deck = deck;
           ViewData["CollectionID"] = new SelectList(_context.Collection, "CollectionID", "CollectionDescription");
           PopulateCollectionsDropDownList(_context);
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

            _context.Attach(Deck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeckExists(Deck.DeckID))
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

        private bool DeckExists(int id)
        {
          return (_context.Deck?.Any(e => e.DeckID == id)).GetValueOrDefault();
        }
    }
}
