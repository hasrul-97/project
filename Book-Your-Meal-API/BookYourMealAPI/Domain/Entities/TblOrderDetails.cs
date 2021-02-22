using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblOrderDetails
    {
        public Guid OrderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public TblItemDetails Item { get; set; }
        public TblOrder Order { get; set; }
    }
}
