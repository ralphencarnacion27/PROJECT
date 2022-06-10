using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using weba_folder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace weba_folder.Models.ViewModels
{
    public class TypeModel
    {
        [Required]
        public Type Type { get; set; }
        public IEnumerable<Item> Items { get; set; }
    
        public IEnumerable<SelectListItem> selectListItem(IEnumerable<Item> Item)
        {
            List<SelectListItem> ItemList = new List<SelectListItem>();    
            SelectListItem sli = new SelectListItem
            {
                Text = "Select Item",
                Value = "0"
            };
            ItemList.Add(sli);
            foreach (Item item in Items)
            {
                sli = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };  
                ItemList.Add(sli);        
            }     
            return ItemList;
        }
    
    
    
    }
}