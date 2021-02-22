using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.CustomExceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class AlreadyDisabledCustomerException:Exception
    {
        public AlreadyDisabledCustomerException(string msg) : base(msg)
        {

        }
    }
}
