using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblItemDetails
    {
        public TblItemDetails()
        {
            TblOrderDetails = new HashSet<TblOrderDetails>();
        }

        public int ItemId { get; set; }
        public Guid? RestaurantId { get; set; }
        public string ItemName { get; set; }
        public int? ItemTypeId { get; set; }
        public decimal ItemPrice { get; set; }
        public int? ItemCategoryId { get; set; }
        public string ItemImage { get; set; }

        public TblItemCategoryDetails ItemCategory { get; set; }
        public TblItemTypeDetails ItemType { get; set; }
        public TblRestaurantDetails Restaurant { get; set; }
        public ICollection<TblOrderDetails> TblOrderDetails { get; set; }
    }
}
