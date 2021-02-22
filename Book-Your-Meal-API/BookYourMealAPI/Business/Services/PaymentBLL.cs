using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Services
{
    public class PaymentBll:IPaymentBll
    {
        private readonly IPaymentDA _dataaccess;
        public PaymentBll(IPaymentDA dataaccess)
        {
            _dataaccess = dataaccess;
        }

        public decimal? GetWalletMoney(Guid userId)
        {
            try
            {
              return _dataaccess.GetWalletMoney(userId);
            }
            catch(Exception e)
            {
                throw new AllException(e.Message);
            }
        }

        [ExcludeFromCodeCoverage]
        public void UpdateWalletMoney(Guid UserID, decimal WalletMoney)
        {
            try
            {
                _dataaccess.UpdateWalletMoney(UserID, WalletMoney);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }

        }
    }
}
