using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookYourMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class OrderController : Controller
    {
       
        private readonly IOrderBll _orderBLL;
        public OrderController(IOrderBll orderBLL)
        {
            _orderBLL = orderBLL;
        }
        [HttpGet]
        [Route("GetAllUserAddress")]
        public ActionResult<List<TblAddressDetails>> GetAllUserAddress(Guid UserId)
        {
            try
            {
                return Ok(_orderBLL.GetAllUserAddress(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut]
        [Route("AddFavouriteRestaurant")]
        public ActionResult AddFavouriteRestaurant(Guid UserID,Guid RestaurantId)
        {
            try
            {
                _orderBLL.AddFavouriteRestaurant(UserID,RestaurantId);
                return Ok(new { message = "Added Favourite" });
            }
            catch (Exception e)
            {
            return BadRequest(new { message = e.Message });
            }

        }
        [HttpPost]
        [Route("RemoveFavouriteRestaurant")]
        public async Task<ActionResult> RemoveFavouriteRestaurant(Guid UserID, Guid RestaurantId)
        {
            try
            {
                await _orderBLL.RemoveFavouriteRestaurant(UserID,RestaurantId);
                return Ok(new { message = "Remove Favourite" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPost]
        [Route("AddReview")]
        public ActionResult AddReview([FromBody]  TblReview tblReview)
        {
            try
            {
                _orderBLL.AddReview(tblReview);
                return Ok(new { message = "Review Added" });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddAddress")]
        public ActionResult AddAddress([FromQuery]  string address, [FromQuery]  Guid userId)
        {
            try
            {
                 return Ok(new { message = _orderBLL.AddAddress(address, userId) });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        
        }
        [HttpGet]
        [Route("GetFavouriteRestaurant")]
        public ActionResult<List<TblFavourite>> GetFavouriteRestaurant(Guid UserId)
        {
            try
            {
                return Ok(_orderBLL.GetFavouriteRestaurant(UserId));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<ActionResult> PlaceOrder(PlaceOrder order)
        {
            try
            {
                return Ok(await _orderBLL.PlaceOrder(order));
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}