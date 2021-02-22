using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{

    [ExcludeFromCodeCoverage]
    public partial class TblItemTypeDetails
    {
        public TblItemTypeDetails()
        {
            TblItemDetails = new HashSet<TblItemDetails>();
        }

        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }

        public ICollection<TblItemDetails> TblItemDetails { get; set; }
    }
}
