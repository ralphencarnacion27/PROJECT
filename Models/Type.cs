using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace weba_folder.Models
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