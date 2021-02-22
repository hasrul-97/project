using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblItemCategoryDetails
    {
        public TblItemCategoryDetails()
        {
            TblItemDetails = new HashSet<TblItemDetails>();
        }

        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }

        public ICollection<TblItemDetails> TblItemDetails { get; set; }
    }
}
