using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Deckollector.Models
{
    public class Deck
    {
        [Key]
        public int DeckID { get; set; }

        [Required]
        [Display(Name ="Deck Name")]
        public string DeckName { get; set; } = string.Empty;

        [Display(Name = "Deck Description")]
        public string DeckDescription { get; set; } = string.Empty;

        public int CollectionID { get; set; }

        [Display(Name = "Collection Name")]
        public Collection? Collection { get; set; }

        public List<Card>? Cards { get; set; }
    }
}
