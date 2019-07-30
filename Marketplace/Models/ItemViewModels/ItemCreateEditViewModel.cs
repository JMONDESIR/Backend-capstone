using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Models.ItemViewModels
{
    public class ItemCreateEditViewModel
    {
        public Item Item { get; set; }
        public List<Status> AvailableStatus { get; set; }
        public List<Category> AvailableCategory { get; set; }

        public List<SelectListItem> CategoryOptions
        {
            get
            {
                if (AvailableCategory == null)
                {
                    return null;
                }
                var cat = AvailableCategory?.Select(c => new SelectListItem(c.Label, c.CategoryId.ToString())).ToList();
                cat.Insert(0, new SelectListItem("Select a category", null));

                return cat;
            }
        }
        public List<SelectListItem> StatusOptions
        {
            get
            {
                if (AvailableStatus == null)
                {
                    return null;
                }
                var stat = AvailableStatus?.Select(s => new SelectListItem(s.ListStatus, s.StatusId.ToString())).ToList();
                stat.Insert(0, new SelectListItem("Choose status", null));

                return stat;
            }
        }
    }
}
