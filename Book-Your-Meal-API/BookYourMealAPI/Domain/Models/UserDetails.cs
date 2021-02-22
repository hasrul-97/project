using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class UserDetails
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public long? UserMobile { get; set; }
        public string UserLocation { get; set; }
        //public decimal? WalletBalance { get; set; }
        public string RoleName { get; set; }

        public string PhotoUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
