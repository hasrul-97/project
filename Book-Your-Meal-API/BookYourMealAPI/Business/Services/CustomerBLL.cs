using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.Business.Services
{
    public class CustomerBll : ICustomerBll
    {
        private readonly ICustomerDA _dataaccess;

        public CustomerBll(ICustomerDA dataaccess)
        {
            _dataaccess = dataaccess;
        }

        public void EditProfile(Guid userId, TblUserDetails tblUserDetails)
        {
            try
            {
                _dataaccess.EditProfile(userId, tblUserDetails);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
             
        }

        public List<BookmarkedRestaurant> GetAllBookMarkedRestaurent(Guid userId)
        {
            try
            {
                return _dataaccess.GetAllBookMarkedRestaurent(userId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public List<RestaurantDetails> GetAllRestaurent()
        {
            try
            {
                return _dataaccess.GetAllRestaurent();
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public List<PastOrderDetails> GetPastOrder(Guid userId)
        {
            try
            {
                return _dataaccess.GetPastOrder(userId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public List<string> GetPastOrderItemDetails(Guid userID)
        {
            try
            {
                return _dataaccess.GetPastOrderItemDetails(userID);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public TblUserDetails GetProfileDetails(Guid userId)
        {
            try
            {
                return _dataaccess.GetProfileDetails(userId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
            
        }

        public List<TblItemDetails> GetResaturentItemDetails(Guid restaurentId)
        {
            try
            {
                return _dataaccess.GetResaturentItemDetails(restaurentId);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
        [ExcludeFromCodeCoverage]
        public List<TblItemDetails> GetAllItemDetails()
        {
            try
            {
                //return _dataaccess.GetAllItemDetails();
                return null;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
        [ExcludeFromCodeCoverage]

        public void RegisterRestaurant(TblApprove tblApprove)
        {
            try
            {
                _dataaccess.RegisterRestaurant(tblApprove);
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
            
        }

        public List<string> Search(string str)
        {
            try
            {
                return _dataaccess.Search(str);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
        }
        public List<ItemRequiredDetails> FilteredItems(Guid restaurantId, Filter filter)
        {
            List<ItemRequiredDetails> AllTblItemDetails = new List<ItemRequiredDetails>();
            List<ItemRequiredDetails> AllTblItemDetail = _dataaccess.GetAllItemDetails(filter);
            foreach (var item in AllTblItemDetail)
            {
                if(item.RestaurantId== restaurantId)
                {
                    AllTblItemDetails.Add(item);
                }
            }
            try
            {
                if (AllTblItemDetails.Count() == 0)
                    throw new EmptyItemException("There is no Item is Available.");
            }
            catch (EmptyItemException e)
            {
                throw new AllException(e.Message);
            }

            catch(Exception e)
            {
                throw new AllException(e.Message);
            }

       
             return AllTblItemDetails;
        }

        public List<RestaurantDetails> GetAllRestaurentLoc(double latitude, double longitude)
        {
            try
            {
                return _dataaccess.GetAllRestaurentLoc(latitude,longitude);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }
    }
}
