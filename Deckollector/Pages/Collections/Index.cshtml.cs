using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;
using Deckollector.Models.CollectionSelectMode;

namespace Deckollector.Pages.Collections
{
    public class IndexModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public IndexModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        public IList<Collection> Collection { get;set; } = default!;

        public CollectionIndexData CollectionData { get; set; }

        public int CollectionID { get; set; }

        public int DeckID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CollectionData = new CollectionIndexData();
            CollectionData.Collections = await _context.Collection
                .Include(c => c.Decks)
                .ToListAsync();

            if (id != null)
            {
                CollectionID = id.Value;
                var selectedCollection = CollectionData.Collections.FirstOrDefault(c => c.CollectionID == id.Value);

                if (selectedCollection != null)
                {
                    CollectionData.Decks = selectedCollection.Decks;
                }
            }

            if (_context.Collection != null)
            {
                Collection = await _context.Collection.ToListAsync();
            }
        }
    }
}
