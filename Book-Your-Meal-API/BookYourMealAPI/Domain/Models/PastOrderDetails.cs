using BookYourMealAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class PastOrderDetails
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public decimal? TotalCost { get; set; }
        public Guid RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public DateTime? OrderDtstamp { get; set; }
        public decimal? Rating { get; set; }
        public Guid OrderDetailsId { get; set; }
        public List<PastOrderItemDetails> ItemDetails { get; set; }
    }
}
