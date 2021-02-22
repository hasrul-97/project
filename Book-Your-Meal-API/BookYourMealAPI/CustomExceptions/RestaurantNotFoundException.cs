using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.CustomExceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class RestaurantNotFoundException:Exception
    {
        public RestaurantNotFoundException(string msg):base(msg)
        {

        }
    }
}
