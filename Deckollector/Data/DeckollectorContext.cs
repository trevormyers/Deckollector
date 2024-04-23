using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Deckollector.Models;

namespace Deckollector.Data
{
    public class DeckollectorContext : DbContext
    {
        public DeckollectorContext (DbContextOptions<DeckollectorContext> options)
            : base(options)
        {
        }

        public DbSet<Deckollector.Models.Card> Card { get; set; } = default!;

        public DbSet<Deckollector.Models.Collection> Collection { get; set; } = default!;

        public DbSet<Deckollector.Models.Deck> Deck { get; set; } = default!;

        public DbSet<Deckollector.Models.Wishlist> Wishlist { get; set; } = default!;
    }
}
