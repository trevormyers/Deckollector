using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deckollector.Models
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }

        [Required]
        [Display(Name = "Card Name")]
        public string CardName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Card Set")]
        public string CardSet { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Card Type")]
        public string CardType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Card Color")]
        public string CardColor { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Card Cost")]
        public string CardCost { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Card Set ID")]
        public int CardSetID { get; set; }

        [ForeignKey("Deck")]
        [Display(Name = "Deck Name")]
        public int DeckID { get; set; }

        [Display(Name = "Deck Name")]
        public Deck? Decks { get; set; }

        [Display(Name = "Wishlist Name")]
        public int? WishlistID { get; set; }

        [Display(Name = "Wishlist Name")]
        public Wishlist? Wishlists { get; set; }
    }
}
