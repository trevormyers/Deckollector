using Deckollector.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Deckollector.Pages.Decks
{
    public class CollectionNamePageModel : PageModel
    {
        public SelectList? CollectionNameSL { get; set; }

        public void PopulateCollectionsDropDownList(DeckollectorContext _context,
            object? selectedCollection = null)
        {
            var collectionsQuery = from c in _context.Collection
                                   orderby c.CollectionName
                                   select c;

            CollectionNameSL = new SelectList(collectionsQuery.AsNoTracking(),
                "CollectionID", "CollectionName", selectedCollection);
        }
    }
}
