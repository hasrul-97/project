using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblAddressDetails
    {
        public TblAddressDetails()
        {
            TblOrder = new HashSet<TblOrder>();
        }

        public Guid AddressId { get; set; }
        public Guid? UserId { get; set; }
        public string Address { get; set; }

        public TblUserDetails User { get; set; }
        public ICollection<TblOrder> TblOrder { get; set; }
    }
}
