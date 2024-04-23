using System.ComponentModel.DataAnnotations;

namespace Deckollector.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistID { get; set; }

        [Required]
        [Display(Name = "Wishlist Name")]
        public string WishlistName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Description")]
        public string? WishlistDescription { get; set; } = string.Empty;

        public List<Card>? Cards { get; set; }
    }
}
