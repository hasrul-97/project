using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Mail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MessageBody { get; set; }
        public string Need { get; set; }
        public string Email { get; set; }
    }
}
