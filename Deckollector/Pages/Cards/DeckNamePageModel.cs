using Deckollector.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Deckollector.Pages.Cards
{
    public class DeckNamePageModel : PageModel
    {
        public SelectList? DeckNameSL { get; set; }

        public void PopulateDecksDropDownList(DeckollectorContext _context,
            object? selectedDeck = null)
        {
            var decksQuery = from d in _context.Deck
                                   orderby d.DeckName
                                   select d;

            DeckNameSL = new SelectList(decksQuery.AsNoTracking(),
                "DeckID", "DeckName", selectedDeck);
        }

        public SelectList? WishlistNameSL { get; set; }

        public void PopulateWishlistsDropDownList(DeckollectorContext _context,
            object? selectedWishlist = null)
        {
            var wishlistsQuery = from w in _context.Wishlist
                                 orderby w.WishlistName
                                 select w;

            WishlistNameSL = new SelectList(wishlistsQuery.AsNoTracking(),
                "WishlistID", "WishlistName", selectedWishlist);
        }
    }
}
