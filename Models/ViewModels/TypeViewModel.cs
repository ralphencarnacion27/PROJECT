using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using bsis3a_webapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bsis3a_webapp.Models.ViewModel
{
    public class TypeViewModel
    {
        public Type Type { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<SelectListItem> selectListItems (IEnumerable<Item> Item)
        {
            List<SelectListItem> ItemList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "Select Item", 
                Value = "0"
            };
             ItemList.Add(sli);

             foreach(Item item in Items)
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