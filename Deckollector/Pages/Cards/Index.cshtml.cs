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
    public class IndexModel : DeckNamePageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public IndexModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string? Filter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? DeckFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public Card CardSelect { get; set; }

        public IList<Card> Card { get; set; } = default!;
        public IList<Deck> Decks { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Populate Decks for dropdown
            Decks = await _context.Deck.ToListAsync();
            PopulateDecksDropDownList(_context);

            var query = _context.Card
                .Include(c => c.Wishlists)
                .Include(c => c.Decks)
                .AsQueryable();

            if (DeckFilter.HasValue)
            {
                // Filter by selected Deck
                query = query.Where(c => c.DeckID == DeckFilter.Value);
            }

            if (!string.IsNullOrEmpty(Filter) && !string.IsNullOrEmpty(Search))
            {
                switch (Filter.ToLower())
                {
                    case "cardtype":
                        query = query.Where(c => c.CardType.Contains(Search));
                        break;
                    case "cardcolor":
                        query = query.Where(c => c.CardColor.Contains(Search));
                        break;
                    case "cardname":
                        query = query.Where(c => c.CardName.Contains(Search));
                        break;
                    case "cardcost":
                        query = query.Where(c => c.CardCost.Contains(Search));
                        break;
                }
            }

            Card = await query.ToListAsync();
        }
    }
}
