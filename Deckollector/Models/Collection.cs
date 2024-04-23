using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Deckollector.Models
{
    public class Collection
    {
        [Key]
        public int CollectionID { get; set; }

        [Required]
        [Display(Name = "Collection Name")]
        public string CollectionName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Description")]
        public string CollectionDescription { get; set; } = string.Empty;

        public List<Deck>? Decks { get; set; }
    }
}
