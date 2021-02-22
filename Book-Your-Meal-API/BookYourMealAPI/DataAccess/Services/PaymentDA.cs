using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Services
{
    [ExcludeFromCodeCoverage]
    public class PaymentDA:IPaymentDA
    {
        private readonly Orchard8Context _DbContext;
        public PaymentDA(Orchard8Context dbContext)
        {
            _DbContext = dbContext;
        }

        public decimal? GetWalletMoney(Guid userId)
        {
            try
            {
                TblUserDetails tblUserDetails = _DbContext.TblUserDetails.Find(userId);
                decimal? walletAmount = tblUserDetails.WalletBalance;
                return walletAmount;
            }
            catch(Exception e)
            {
                throw new AllException(e.Message);
            }
        }
    
        public void UpdateWalletMoney(Guid UserId, decimal WalletMoney)
        {
            try
            {
                TblUserDetails tbluserdetails = new TblUserDetails();
                tbluserdetails = _DbContext.TblUserDetails.Find(UserId);
                if (tbluserdetails.WalletBalance - WalletMoney > 0)
                {
                    tbluserdetails.WalletBalance = tbluserdetails.WalletBalance - WalletMoney;
                }
                else
                {
                    throw new LowBalanceException("Sorry,You have Low Balance");
                }
                _DbContext.SaveChanges();
            }
            catch (LowBalanceException e)
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
        }

    }
}
