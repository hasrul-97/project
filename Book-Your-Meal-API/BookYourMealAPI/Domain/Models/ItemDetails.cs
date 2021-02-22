using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class ItemDetails
    {
        public Guid? RestaurantId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? ItemTypeId { get; set; }
        public decimal ItemPrice { get; set; }
        public int? ItemCategoryId { get; set; }
        public string ItemImage { get; set; }
    }
}
