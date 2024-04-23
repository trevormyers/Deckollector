using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;
using Deckollector.Models.DeckSelectMode;

namespace Deckollector.Pages.Decks
{
    public class IndexModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public IndexModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        public IList<Deck> Deck { get; set; } = default!;

        public DeckIndexData DeckData { get; set; }
        
        public int DeckID { get; set; }

        public int CardID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            DeckData = new DeckIndexData();
            DeckData.Decks = await _context.Deck
                .Include(d => d.Cards)
                .ToListAsync();

            if (id != null)
            {
                DeckID = id.Value;
                var selectedDeck = DeckData.Decks.FirstOrDefault(d => d.DeckID == id.Value);

                if (selectedDeck != null)
                {
                    DeckData.Cards = selectedDeck.Cards;
                }
            }

            Deck = await _context.Deck
                .Include(d => d.Collection)
                .ToListAsync();
        }
    }
}
