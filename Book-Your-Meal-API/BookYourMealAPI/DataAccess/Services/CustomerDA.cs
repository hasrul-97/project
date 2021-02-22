using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace BookYourMealAPI.DataAccess.Services
{
    [ExcludeFromCodeCoverage]
    public class CustomerDA : ICustomerDA
    {
        private readonly Orchard8Context _DbContext;
        public CustomerDA(Orchard8Context dbContext)
        {
            _DbContext = dbContext;
        }
        public void EditProfile(Guid userId, TblUserDetails tblUserDetails)
        {
            try
            {
                TblUserDetails TemptblUserDetails=_DbContext.TblUserDetails.Find(userId);
                TemptblUserDetails.Name = tblUserDetails.Name;
                TemptblUserDetails.UserMobile = tblUserDetails.UserMobile;
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

        public List<BookmarkedRestaurant> GetAllBookMarkedRestaurent(Guid userId)
        {
            try
            {
                List<BookmarkedRestaurant> allBookMarkedRestaurent = new List<BookmarkedRestaurant>();
                var list = from a in _DbContext.TblFavourite
                           join b in _DbContext.TblRestaurantDetails on a.RestaurantId equals b.RestaurantId
                           join c in _DbContext.TblApprove on b.UserId equals c.UserId
                           join d in _DbContext.TblUserDetails on b.UserId equals d.UserId
                           select new
                           {
                               a.UserId,
                               a.FavouriteId,
                               a.RestaurantId,
                               c.RestaurantName,
                               b.Discounts,
                               b.Rating,
                               d.ActiveUserId,
                               b.RestaurantImageUrl
                           };
                foreach (var item in list)
                {
                    BookmarkedRestaurant bookmarkedRestaurant = new BookmarkedRestaurant();
                    bookmarkedRestaurant.RestaurantId = item.RestaurantId;
                    bookmarkedRestaurant.RestaurantName = item.RestaurantName;
                    bookmarkedRestaurant.UserId = item.UserId;
                    bookmarkedRestaurant.RestaurantImageUrl = item.RestaurantImageUrl;
                    bookmarkedRestaurant.FavouriteId = item.FavouriteId;
                    bookmarkedRestaurant.Discounts = item.Discounts;
                    bookmarkedRestaurant.Rating = item.Rating;
                    bookmarkedRestaurant.ActiveUserId = item.ActiveUserId;
                    allBookMarkedRestaurent.Add(bookmarkedRestaurant);
                }
                allBookMarkedRestaurent = allBookMarkedRestaurent.FindAll(x => x.ActiveUserId == 1);
                return allBookMarkedRestaurent;
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

        public List<RestaurantDetails> GetAllRestaurent()
        {
            try
            {
                List<RestaurantDetails> tblRestaurantRequiredDetails = new List<RestaurantDetails>();
                var Value = from x in _DbContext.TblRestaurantDetails
                            join y in _DbContext.TblApprove on x.ApproveId equals y.ApproveId
                            join z in _DbContext.TblUserDetails on y.UserId equals z.UserId
                            //join p in _DbContext.TblAddressDetails on z.UserId equals p.UserId
                            select new
                            {
                                x.Rating,
                                x.RestaurantId,
                                x.Discounts,
                                y.RestaurantName,
                                z.UserMobile
                            };

                foreach (var item in Value)
                {
                    RestaurantDetails requiredDetails = new RestaurantDetails();
                    requiredDetails.Rating = item.Rating;
                    requiredDetails.RestaurantId = item.RestaurantId;
                    requiredDetails.UserMobile = item.UserMobile;
                    requiredDetails.RestaurantName = item.RestaurantName;
                    requiredDetails.Discounts = item.Discounts;
                    tblRestaurantRequiredDetails.Add(requiredDetails);
                }
                if(tblRestaurantRequiredDetails.Count==0)
                {
                    throw new RestaurantNotFoundException("Sorry , No restaurant Found");
                }
                else
                {
                    return tblRestaurantRequiredDetails;
                }

               
            }
            catch (RestaurantNotFoundException e)
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

        public List<PastOrderDetails> GetPastOrder(Guid userId)
        {
            try
            {
                List<PastOrderDetails> tblOrders = new List<PastOrderDetails>();
                var orderList = from x in _DbContext.TblOrder
                                join a in _DbContext.TblRestaurantDetails on x.RestaurantId equals a.RestaurantId
                                join b in _DbContext.TblApprove on a.UserId equals b.UserId
                                where x.UserId.Equals(userId)
                                select new
                                {
                                    b.RestaurantName,
                                    x.OrderId,
                                    x.OrderDtstamp,
                                    x.RestaurantId,
                                    x.TotalCost
                                };
                List<PastOrderDetails> pastOrderDetailList = new List<PastOrderDetails>();
                foreach (var item in orderList)
                {
                    List<PastOrderItemDetails> ItemDetailsList = HelperMethod_GetItemDetails(item.OrderId);
                    PastOrderDetails pastOrderDetail = new PastOrderDetails();
                    pastOrderDetail.RestaurantId = item.RestaurantId;
                    pastOrderDetail.OrderId = item.OrderId;
                    pastOrderDetail.OrderDtstamp = item.OrderDtstamp;
                    pastOrderDetail.RestaurantName = item.RestaurantName;
                    pastOrderDetail.TotalCost = item.TotalCost;
                    pastOrderDetail.UserId = userId;
                    pastOrderDetail.ItemDetails = ItemDetailsList;
                    pastOrderDetailList.Add(pastOrderDetail);
                }
                return pastOrderDetailList;
            }
            catch (PastOrderNotFoundException e)
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


        public List<PastOrderItemDetails> HelperMethod_GetItemDetails(Guid orderId)
        {
            var OrderitemId = from a in _DbContext.TblOrderDetails
                              join b in _DbContext.TblItemDetails on a.ItemId equals b.ItemId
                              where a.OrderId == orderId
                              select new
                              {
                                  a.OrderDetailsId,
                                  a.OrderId,
                                  a.ItemId,
                                  a.Quantity,
                                  b.ItemName,
                                  b.ItemPrice
                              };
            List<PastOrderItemDetails> itemDetailsList = new List<PastOrderItemDetails>();
            foreach (var item in OrderitemId)
            {
                PastOrderItemDetails orderDetails = new PastOrderItemDetails();
                orderDetails.OrderDetailsId = item.OrderDetailsId;
                orderDetails.OrderId = item.OrderId;
                orderDetails.Quantity = item.Quantity;
                orderDetails.ItemId = item.ItemId;
                orderDetails.ItemName = item.ItemName;
                orderDetails.ItemPrice = item.ItemPrice;
                itemDetailsList.Add(orderDetails);
            }
            return itemDetailsList;
        }

        public List<string> GetPastOrderItemDetails(Guid userId)
        {
            try
            {
                List<string> pastOrderDetails = new List<string>();
                var pastOrderValue = from x in _DbContext.TblOrder
                                     join y in _DbContext.TblOrderDetails on x.OrderId equals y.OrderId
                                     join z in _DbContext.TblItemDetails on y.ItemId equals z.ItemId
                                     where x.UserId.Equals(userId)
                                     select new
                                     {
                                         z.ItemName

                                     };

                foreach (var item in pastOrderValue)
                {
                    pastOrderDetails.Add(item.ItemName);
                }
                return pastOrderDetails;
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
        public List<ItemRequiredDetails> GetAllItemDetails(Filter filter)
        {
            List<string> typeFilters = filter.Typefilters;
            List<string> categoryFilters = filter.Categoryfilters;
            try
            {
                List<TblItemDetails> tblItemDetails = new List<TblItemDetails>();
                tblItemDetails = _DbContext.TblItemDetails.ToList();
                var tblItemDetails1 = from data in tblItemDetails
                                      join data1 in _DbContext.TblItemTypeDetails on data.ItemTypeId equals data1.ItemTypeId
                                      join data2 in _DbContext.TblItemCategoryDetails on data.ItemCategoryId equals data2.ItemCategoryId
             
                                      select new
                                      {
                                          ItemId = data.ItemId,
                                          ItemType = data1.ItemTypeName,
                                          ItemCategory = data2.ItemCategoryName,
                                          ResturantId = data.RestaurantId,
                                          ItemImage=data.ItemImage,
                                          ItemName=data.ItemName,
                                          ItemPrice=data.ItemPrice,
                                      };
                if((typeFilters.Count > 0 && typeFilters != null) && (categoryFilters.Count > 0 && categoryFilters != null))
                {
                    tblItemDetails1 = tblItemDetails1.Where(a => categoryFilters.Contains(a.ItemCategory) || typeFilters.Contains(a.ItemType));
                   
                }
                else if(categoryFilters.Count > 0 && categoryFilters != null)
                {
                    tblItemDetails1 = tblItemDetails1.Where(a => categoryFilters.Contains(a.ItemCategory));
                }
                else
                {
                    tblItemDetails1 = tblItemDetails1.Where(a => typeFilters.Contains(a.ItemType));
                }
               
                List<ItemRequiredDetails> requiredItemDetails = new List<ItemRequiredDetails>();
                ItemRequiredDetails requiredItemDetail;
                foreach(var eachItem in tblItemDetails1)
                {
                    requiredItemDetail = new ItemRequiredDetails();
                    requiredItemDetail.ItemId = eachItem.ItemId;
                    requiredItemDetail.ItemImage = eachItem.ItemImage;
                    requiredItemDetail.ItemName = eachItem.ItemName;
                    requiredItemDetail.ItemPrice = eachItem.ItemPrice;
                    requiredItemDetail.RestaurantId = eachItem.ResturantId;

                    requiredItemDetails.Add(requiredItemDetail);
                }
                //requiredItemDetails = requiredItemDetails.Where(a=>typeFilters.Contains(a.ItemType)).ToList();
                return requiredItemDetails;
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

        public TblUserDetails GetProfileDetails(Guid userId)
        {
            try
            {
                TblUserDetails tblUserDetails = new TblUserDetails();
                var userDetails= _DbContext.TblUserDetails.Where(i=>i.UserId== userId).Select(t=>new TblUserDetails
                { Name=t.Name,UserMobile=t.UserMobile, PhotoUrl=t.PhotoUrl, Email=t.Email});
                foreach (var item in userDetails)
                {
                    tblUserDetails.Email = item.Email; tblUserDetails.Name = item.Name;
                    tblUserDetails.UserMobile=item.UserMobile; tblUserDetails.PhotoUrl=item.PhotoUrl;
                }
                return tblUserDetails;

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

        public List<TblItemDetails> GetResaturentItemDetails(Guid restaurentId)
        {
            try
            {
                List<TblItemDetails> allRestaurentItems = new List<TblItemDetails>();
                var list = _DbContext.TblItemDetails.Where(i => i.RestaurantId == restaurentId);
                foreach (var item in list)
                {
                    allRestaurentItems.Add(item);
                }
                if(allRestaurentItems.Count==0)
                {
                    throw new ItemNotFoundException("sorry , No Items Available");
                } 
             return allRestaurentItems;            
            }
            catch (RestaurantNotFoundException e)
            {
                throw new AllException(e.Message);
            }
            catch (SqlException e )
            {

                throw new AllException(e.Message);
            }
            catch (Exception e)
            {

                throw new AllException(e.Message);
            }
           
        }

        public void RegisterRestaurant(TblApprove tblApprove)
        {
            try
            {
                List<TblApprove> tblApproves = _DbContext.TblApprove.ToList<TblApprove>();
                foreach (var item in tblApproves)
                {
                    if (item.UserId == tblApprove.UserId)
                    {
                        throw new AlreadyRegisteredRestaurantException("Already Requested for Restaurant");
                    }
                }
                _DbContext.TblApprove.Add(tblApprove);
                _DbContext.SaveChanges();
            }
            catch (AlreadyRegisteredRestaurantException e)
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
        public List<ItemRequiredDetails> RequiredItemDetails(List<TblItemDetails> allTblItemDetails)
        {
            List<ItemRequiredDetails> allItems = new List<ItemRequiredDetails>();
            ItemRequiredDetails eachItem;
            foreach (var item in allTblItemDetails)
            {
                eachItem = new ItemRequiredDetails();
                eachItem.ItemId = item.ItemId;
                eachItem.ItemImage = item.ItemImage;
                eachItem.ItemPrice = item.ItemPrice;
                eachItem.RestaurantId = item.RestaurantId;
                eachItem.ItemImage = item.ItemImage;
                allItems.Add(eachItem);
            }
            return allItems;
        }
        public List<string> Search(string str)
        {

            List<TblApprove> tblApproves = new List<TblApprove>();
            List<TblRestaurantDetails> tblRestaurantDetails = new List<TblRestaurantDetails>();
            List<TblItemDetails> tblItemDetails = new List<TblItemDetails>();
            tblApproves = _DbContext.TblApprove.ToList();
            tblRestaurantDetails = _DbContext.TblRestaurantDetails.ToList();
            tblItemDetails = _DbContext.TblItemDetails.ToList();
            var requiredresults = from data in tblItemDetails
                                  join data1 in tblRestaurantDetails on data.RestaurantId equals data1.RestaurantId
                                  join data2 in tblApproves on data1.UserId equals data2.UserId
                                  select new
                                  {
                                      data.ItemName,
                                      data.ItemPrice,
                                      data1.Rating,
                                      data1.Discounts,
                                      data2.RestaurantName,
                                  };
           
            requiredresults = requiredresults.Where(a => str.Contains(a.ItemName));
            requiredresults = requiredresults.Where(a => str.Contains(a.RestaurantName));
           



            return null;
        }

        public List<RestaurantDetails> GetAllRestaurentLoc(double latitude,double longitude)
        {
            try
            {
                List<RestaurantDetails> tblRestaurantRequiredDetails = new List<RestaurantDetails>();
                var Value = from x in _DbContext.TblRestaurantDetails
                            join y in _DbContext.TblApprove on x.ApproveId equals y.ApproveId
                            join z in _DbContext.TblUserDetails on y.UserId equals z.UserId
                            //join p in _DbContext.TblAddressDetails on z.UserId equals p.UserId
                            where (GetDistanceBetweenPoints(latitude,longitude,Convert.ToDouble(z.Latitude), Convert.ToDouble(z.Longitude))>100)
                            select new
                            {
                                x.Rating,
                                x.RestaurantId,
                                x.Discounts,
                                y.RestaurantName,
                                z.UserMobile,
                                z.Latitude,
                                z.Longitude,
                                z.ActiveUserId,
                                x.RestaurantImageUrl
                            };

                foreach (var item in Value)
                {
                    RestaurantDetails requiredDetails = new RestaurantDetails();
                    requiredDetails.Rating = item.Rating;
                    requiredDetails.RestaurantImageUrl = item.RestaurantImageUrl;
                    requiredDetails.RestaurantId = item.RestaurantId;
                    requiredDetails.UserMobile = item.UserMobile;
                    requiredDetails.RestaurantName = item.RestaurantName;
                    requiredDetails.Discounts = item.Discounts;
                    requiredDetails.ActiveUserId = item.ActiveUserId;
                    tblRestaurantRequiredDetails.Add(requiredDetails);
                }
                if (tblRestaurantRequiredDetails.Count == 0)
                {
                    throw new RestaurantNotFoundException("Sorry , No restaurant Found");
                }
                else
                {
                    tblRestaurantRequiredDetails = tblRestaurantRequiredDetails.FindAll(x => x.ActiveUserId == 1);
                    return tblRestaurantRequiredDetails;
                }


            }
            catch (RestaurantNotFoundException e)
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
        public double GetDistanceBetweenPoints(double lat1, double long1, double lat2, double long2)
        {
            double distance = 0;

            double dLat = (lat2 - lat1) / 180 * Math.PI;
            double dLong = (long2 - long1) / 180 * Math.PI;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                        + Math.Cos(lat2) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            //Calculate radius of earth
            // For this you can assume any of the two points.
            double radiusE = 6378135; // Equatorial radius, in metres
            double radiusP = 6356750; // Polar Radius

            //Numerator part of function
            double nr = Math.Pow(radiusE * radiusP * Math.Cos(lat1 / 180 * Math.PI), 2);
            //Denominator part of the function
            double dr = Math.Pow(radiusE * Math.Cos(lat1 / 180 * Math.PI), 2)
                            + Math.Pow(radiusP * Math.Sin(lat1 / 180 * Math.PI), 2);
            double radius = Math.Sqrt(nr / dr);

            //Calaculate distance in metres.
            distance = radius * c;
            return distance;
        }

    }
}
