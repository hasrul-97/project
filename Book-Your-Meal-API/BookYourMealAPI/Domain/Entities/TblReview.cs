using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblReview
    {
        public int ReviewId { get; set; }
        public string Reviews { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }

        public TblOrder Order { get; set; }
        public TblUserDetails User { get; set; }
    }
}
