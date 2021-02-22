using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblApprove
    {
        public TblApprove()
        {
            TblRestaurantDetails = new HashSet<TblRestaurantDetails>();
        }

        public int ApproveId { get; set; }
        public string RestaurantName { get; set; }
        public Guid? UserId { get; set; }
        public int ApprovalStatusId { get; set; }

        public TblApprovalStatus ApprovalStatus { get; set; }
        public TblUserDetails User { get; set; }
        public ICollection<TblRestaurantDetails> TblRestaurantDetails { get; set; }
    }
}
