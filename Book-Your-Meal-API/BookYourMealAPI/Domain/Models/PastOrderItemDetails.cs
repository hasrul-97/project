using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class PastOrderItemDetails
    {
        public Guid OrderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
