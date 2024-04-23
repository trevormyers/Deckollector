using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Deckollector.Data;
using Deckollector.Models;
using Deckollector.Models.WishlistSelectMode;

namespace Deckollector.Pages.Wishlists
{
    public class IndexModel : PageModel
    {
        private readonly Deckollector.Data.DeckollectorContext _context;

        public IndexModel(Deckollector.Data.DeckollectorContext context)
        {
            _context = context;
        }

        public IList<Wishlist> Wishlist { get; set; } = default!;

        public WishlistIndexData WishlistData { get; set; }

        public int WishlistID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            WishlistData = new WishlistIndexData();
            WishlistData.Wishlists = await _context.Wishlist
                .Include(w => w.Cards)
                .ToListAsync();

            if (id != null)
            {
                WishlistID = id.Value;
                var selectedWishlist = WishlistData.Wishlists.FirstOrDefault(w => w.WishlistID == id.Value);

                if (selectedWishlist != null)
                {
                    WishlistData.Cards = selectedWishlist.Cards;
                }
            }

            if (_context.Wishlist != null)
            {
                Wishlist = await _context.Wishlist.ToListAsync();
            }
        }
    }
}
