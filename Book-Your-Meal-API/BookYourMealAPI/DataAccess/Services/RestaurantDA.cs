using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourMealAPI.DataAccess.Services
{
    public class RestaurantDA: IRestaurantDA
    {
        private readonly Orchard8Context _DbContext;
        public RestaurantDA(Orchard8Context dbContext)
        {
            _DbContext = dbContext;
        }
       
        public async Task<bool> AddItem(TblItemDetails tblItemDetails)
        {
            try
            {
                _DbContext.TblItemDetails.Add(tblItemDetails);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
            
        }

       
        public async Task<bool> DeleteItem(int itemId, Guid restaurantId)
        {
            try
            {
                TblItemDetails itemDetails = new TblItemDetails();
                itemDetails = _DbContext.TblItemDetails.Find(itemId);
                _DbContext.Remove(itemDetails);
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        
        public async Task<bool> EditItem(TblItemDetails tblItemDetails)
        {
            try
            {
                TblItemDetails itemDetails = new TblItemDetails();
                itemDetails = _DbContext.TblItemDetails.Find(tblItemDetails.ItemId);
                itemDetails.ItemName = tblItemDetails.ItemName;
                itemDetails.ItemPrice = tblItemDetails.ItemPrice;
                itemDetails.ItemTypeId = tblItemDetails.ItemTypeId;
                itemDetails.ItemCategoryId = tblItemDetails.ItemCategoryId;
                itemDetails.ItemImage = tblItemDetails.ItemImage;
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
        }

     
        public async Task<bool> EditRestaurantDetails(RestaurantDetails RestaurantDetails)
        {
            try
            {
                TblRestaurantDetails tblRestaurantDetails = new TblRestaurantDetails();
                TblUserDetails tblUserDetails = new TblUserDetails();
                TblApprove tblApprove = new TblApprove();
                tblRestaurantDetails = _DbContext.TblRestaurantDetails.Find(RestaurantDetails.RestaurantId);
                tblRestaurantDetails.Discounts = RestaurantDetails.Discounts;
                tblRestaurantDetails.RestaurantAvailabilityId = RestaurantDetails.RestaurantAvailabilityId;
                tblRestaurantDetails.RestaurantImageUrl = RestaurantDetails.RestaurantImageUrl;
                _DbContext.SaveChanges();

                tblUserDetails = _DbContext.TblUserDetails.Find(tblRestaurantDetails.UserId);
                tblUserDetails.UserMobile = RestaurantDetails.UserMobile;
                _DbContext.SaveChanges();

                tblApprove = _DbContext.TblApprove.Find(tblRestaurantDetails.ApproveId);
                tblApprove.RestaurantName = RestaurantDetails.RestaurantName;
                await _DbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
        }

        public List<TblItemCategoryDetails> GetItemCategory()
        {
            try
            {

                List<TblItemCategoryDetails> tblItemCategoryDetails = new List<TblItemCategoryDetails>();
                tblItemCategoryDetails = _DbContext.TblItemCategoryDetails.ToList();
                return tblItemCategoryDetails;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        public List<TblItemTypeDetails> GetItemType()
        {
            try
            {
                List<TblItemTypeDetails> tblItemTypeDetails = new List<TblItemTypeDetails>();
                tblItemTypeDetails = _DbContext.TblItemTypeDetails.ToList();
                return tblItemTypeDetails;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
        }

        public RestaurantDetails GetRestaurantDetails(Guid userId)
        {
            try
            {

                var list = from x in _DbContext.TblRestaurantDetails
                            join y in _DbContext.TblApprove on x.ApproveId equals y.ApproveId
                           where x.UserId== userId
                            select new
                            {
                                x.Rating,
                                x.Discounts,
                                x.RestaurantId,
                                x.RestaurantImageUrl,
                                x.RestaurantAvailabilityId,
                                y.RestaurantName
                            };
                RestaurantDetails restaurantDetails = new RestaurantDetails();
                foreach (var item in list)
                {
                    restaurantDetails.RestaurantImageUrl = item.RestaurantImageUrl;
                    restaurantDetails.RestaurantId = item.RestaurantId;
                    restaurantDetails.RestaurantName=item.RestaurantName;
                    restaurantDetails.Rating=item.Rating;
                    restaurantDetails.RestaurantAvailabilityId=item.RestaurantAvailabilityId;
                    restaurantDetails.Discounts = item.Discounts;
                }
                return restaurantDetails;
            }
            catch (Exception e )
            {

                throw new AllException(e.Message);
            }
        }

        public List<TblItemDetails> GetRestaurantItems(Guid restaurantId)
        {
            try
            {
                List<TblItemDetails> tblItemDetails = new List<TblItemDetails>();
                var list = _DbContext.TblItemDetails.Where(x => x.RestaurantId == restaurantId);
                foreach (var item in list)
                {
                    tblItemDetails.Add(item);
                }
                return tblItemDetails;
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
            
        }

        public async Task<bool> UpdateRestaurantDiscount(Guid restaurantId, decimal discounts)
        {
            try
            {
                TblRestaurantDetails tblRestaurantDetails = new TblRestaurantDetails();
                tblRestaurantDetails = _DbContext.TblRestaurantDetails.Find(restaurantId);
                tblRestaurantDetails.Discounts = discounts;
                await _DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new AllException(e.Message);
            }
           
        }
        
    }
}
