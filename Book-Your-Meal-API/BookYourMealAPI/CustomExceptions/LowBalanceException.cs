using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.CustomExceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class LowBalanceException:Exception
    {
        public LowBalanceException(string msg) : base(msg)
        {

        }
    }

}
