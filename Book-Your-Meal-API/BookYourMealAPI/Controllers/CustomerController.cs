using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookYourMealAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBll _customerBA;
        public CustomerController(ICustomerBll customerBA)
        {
            _customerBA = customerBA;
        }

        [HttpGet]
        [Route("GetPastOrder")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetPastOrder(Guid userID)
        {
            try
            {
                return Ok(_customerBA.GetPastOrder(userID));
                //PastOrderDetails order = new PastOrderDetails();
                //return Ok(order);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
               
        }
        [HttpGet]
        [Route("GetPastOrderDetails")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetPastOrderItemDetails(Guid userID)
        {
            try
            {
                return Ok(_customerBA.GetPastOrderItemDetails(userID));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
         

        }
        [HttpGet]
        [Route("GetAllRestaurent")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetAllRestaurent()
        {
            try
            {
                return Ok(_customerBA.GetAllRestaurent());
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
          
        }

        [HttpGet]
        [Route("GetAllRestaurentLoc")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetAllRestaurentLoc(double latitude, double longitude)
        {
            try
            {
                return Ok(_customerBA.GetAllRestaurentLoc(latitude,longitude));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet]
        [Route("GetAllBookMarkedRestaurent")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetAllBookMarkedRestaurent(Guid userID)
        {
            try
            {
                return Ok(_customerBA.GetAllBookMarkedRestaurent(userID));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet]
        [Route("GetProfileDetails")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetProfileDetails(Guid userID)
        {
            try
            {
                return Ok(_customerBA.GetProfileDetails(userID));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("EditProfile")]
        [ExcludeFromCodeCoverage]
        public IActionResult EditProfile(Guid userID,[FromBody] UserDetails UserDetails)
        {
            try
            {
                TblUserDetails tblUserDetails = new TblUserDetails();
                tblUserDetails.Name=UserDetails.Name;
                tblUserDetails.Latitude=UserDetails.Latitude;
                tblUserDetails.Longitude = UserDetails.Longitude;
                tblUserDetails.UserMobile=UserDetails.UserMobile;
                _customerBA.EditProfile(userID, tblUserDetails);
                return Ok(new { message = "User Profile Updated Successfully" });
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
         
        }
       
        [HttpPost]
        [Route("Search")]
        [ExcludeFromCodeCoverage]
        public IActionResult Search(string str)
        {
            try
            {
                return Ok(_customerBA.Search(str));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }

        }
        [HttpGet]
        [Route("GetResaturentItemDetails")]
        [ExcludeFromCodeCoverage]
        public IActionResult GetResaturentItemDetails(Guid restaurentId)
        {
            try
            {
                return Ok(_customerBA.GetResaturentItemDetails(restaurentId));
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
           
        }
        [HttpPost]
        [Route("RegisterRestaurant")]
        [ExcludeFromCodeCoverage]
        public IActionResult RegisterRestaurant(Approve approve)
        {
            try
            {
                TblApprove tblApprove = new TblApprove();
                tblApprove.RestaurantName=approve.RestaurantName;
                tblApprove.UserId=approve.UserId;
                tblApprove.ApprovalStatusId = 2;
                _customerBA.RegisterRestaurant(tblApprove);
                return Ok(new { message = " Restaurent Request Successfully submitted" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }
        [HttpPost]
        [Route("FilteredItems")]
        [ExcludeFromCodeCoverage]
        public ActionResult FilteredItems(Guid restaurantId,[FromBody] Filter filter)
        {
            List<ItemRequiredDetails> fiteredItems = new List<ItemRequiredDetails>();
            try
            {
                fiteredItems = _customerBA.FilteredItems(restaurantId,filter);
               // return Ok(fiteredItems);
            }
            catch(Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            return Ok(fiteredItems);
        }
        [HttpGet]
        [Route("GetAllItemDetails")]
        [ExcludeFromCodeCoverage]
        public ActionResult<List<TblItemDetails>> GetAllItemDetails()
        {
            try
            {
                return Ok(_customerBA.GetAllItemDetails());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    
      
    }
}