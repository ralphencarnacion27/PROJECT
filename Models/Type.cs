using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bsis3a_webapp.Models
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Type Name")]
        public string Name { get; set; }

        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}