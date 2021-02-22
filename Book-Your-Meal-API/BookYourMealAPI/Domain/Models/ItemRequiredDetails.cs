using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class ItemRequiredDetails
    {
        public int ItemId { get; set; }
        public Guid? RestaurantId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemImage { get; set; }
        public string ItemType { get; set; }
        public string ItemCategory { get; set; }
        //public Guid restaurantId { get; set; }
        //public string restaurantName { get; set; }
        //public string restaurantDiscount { get; set; }
        //public string restaurantRating { get; set; }
    }
}
