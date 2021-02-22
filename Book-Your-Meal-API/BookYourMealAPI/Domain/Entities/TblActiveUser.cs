using System;
using System.Collections.Generic;

namespace BookYourMealAPI.Domain.Entities
{
    public partial class TblActiveUser
    {
        public TblActiveUser()
        {
            TblUserDetails = new HashSet<TblUserDetails>();
        }

        public int ActiveUserId { get; set; }
        public string ActiveUser { get; set; }

        public ICollection<TblUserDetails> TblUserDetails { get; set; }
    }
}
