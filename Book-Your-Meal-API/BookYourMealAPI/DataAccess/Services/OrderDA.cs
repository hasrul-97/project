using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Services
{
    [ExcludeFromCodeCoverage]
    public class OrderDA : IOrderDA
    {
        private readonly Orchard8Context _DbContext;
        public OrderDA(Orchard8Context dbContext)
        {
            _DbContext = dbContext;
        }
        public List<TblAddressDetails> GetAllUserAddress(Guid UserId)
        {
            try
            {
                List<TblAddressDetails> TblAddressDetailslist = new List<TblAddressDetails>();
                List<TblAddressDetails> TblAddressDetailslist1 = new List<TblAddressDetails>();
                TblAddressDetailslist = _DbContext.TblAddressDetails.ToList<TblAddressDetails>();
                foreach(var item in TblAddressDetailslist)
                {
                    if(item.UserId==UserId)
                    {
                        TblAddressDetailslist1.Add(item);
                    }
                }
                return TblAddressDetailslist1;
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
        public void AddFavouriteRestaurant(Guid UserID, Guid RestaurantId)
        {
            try
            {
                TblFavourite TblFavouritedetail = new TblFavourite();
                TblFavouritedetail.UserId = UserID;
                TblFavouritedetail.RestaurantId = RestaurantId;
                _DbContext.TblFavourite.Add(TblFavouritedetail);
                _DbContext.SaveChanges();
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
        public  async Task RemoveFavouriteRestaurant(Guid UserID, Guid RestaurantId)
        {
            try
            {
                List<TblFavourite> TblFavouritedetail = new List<TblFavourite>();
                TblFavouritedetail = _DbContext.TblFavourite.ToList();
                foreach(var item in TblFavouritedetail)
                {
                    if(item.UserId==UserID && item.RestaurantId==RestaurantId)
                    {
                        _DbContext.TblFavourite.Remove(item);
                    }
                }
                await _DbContext.SaveChangesAsync();
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
        public void AddReview(TblReview tblReview)
        {
            try
            {
                _DbContext.TblReview.Add(tblReview);
                _DbContext.SaveChanges();
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
        public Guid AddAddress(string address,Guid id)
        {

            try
            {
                TblAddressDetails tblAddressDetails = new TblAddressDetails();
                tblAddressDetails.AddressId = Guid.NewGuid();
                var temp = tblAddressDetails.AddressId;
                tblAddressDetails.Address = address;
                tblAddressDetails.UserId = id;
                _DbContext.TblAddressDetails.Add(tblAddressDetails);
                int value=_DbContext.SaveChanges();
                if (value > 0)
                    return temp;
                else
                    throw new Exception();
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
        public List<TblFavourite> GetFavouriteRestaurant(Guid UserId)
        {
            try
            {
                List<TblFavourite> TblFavouritelist = new List<TblFavourite>();
                List<TblFavourite> TblFavouritelist1 = new List<TblFavourite>();
                foreach (var item in TblFavouritelist)
                {
                    if (item.UserId == UserId)
                    {
                        TblFavouritelist1.Add(item);
                    }
                }
                TblFavouritelist = _DbContext.TblFavourite.ToList<TblFavourite>();

                return TblFavouritelist1;
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

        public async Task<bool> PlaceOrder(PlaceOrder order)
        {
            try
            {

                TblOrder orderValue = new TblOrder();
                orderValue.OrderId = Guid.NewGuid();
                orderValue.RestaurantId = order.RestaurantId;
                orderValue.UserId = order.UserId;
                orderValue.TotalCost = order.TotalCost;
                orderValue.OrderDtstamp = DateTime.Now;
                orderValue.AddressId = order.AddressId;
                _DbContext.TblOrder.Add(orderValue);

                foreach (var item in order.OrderDetails)
                {
                    TblOrderDetails orderDetails = new TblOrderDetails();
                    orderDetails.ItemId = item.ItemId;
                    orderDetails.OrderId = orderValue.OrderId;
                    orderDetails.Quantity = item.Quantity;
                    orderDetails.OrderDetailsId = Guid.NewGuid();
                    _DbContext.TblOrderDetails.Add(orderDetails);                                
                }

                int a=await _DbContext.SaveChangesAsync();
                if (a > 0)
                    return true;
                else
                    return false;

            }
            catch(SqlException e)
            {
                throw new AllException(e.Message);
            }
            catch(Exception e)
            {
                throw new AllException(e.Message);
            }
        }
    }
}
