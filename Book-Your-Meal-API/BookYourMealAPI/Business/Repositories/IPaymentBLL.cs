using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Repositories
{
    public interface IPaymentBll
    {
        decimal? GetWalletMoney(Guid userId);
        void UpdateWalletMoney(Guid UserID, decimal WalletMoney);
    }
}
