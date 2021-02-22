using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public partial class TblRole
    {
        public TblRole()
        {
            TblUserDetails = new HashSet<TblUserDetails>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<TblUserDetails> TblUserDetails { get; set; }
    }
}
