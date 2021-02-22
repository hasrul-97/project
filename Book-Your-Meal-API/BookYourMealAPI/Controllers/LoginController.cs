using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookYourMealAPI.BookYourMealAPI.Controllers
{
   
    [ApiController, Route("api/[controller]")]
    [EnableCors("AllAllowPolicy")]
    [ExcludeFromCodeCoverage]
    public class LoginController : Controller
    {
        private readonly ILoginBll _loginBusiness;
    
        public LoginController(ILoginBll loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult Post([FromBody]TblUserDetails tblUserDetails)
        {
            try
            {
                tblUserDetails.ActiveUserId = 1;
                _loginBusiness.AddUser(tblUserDetails);
                return Ok(_loginBusiness.AddUser(tblUserDetails));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
      
        [HttpGet]
        [Route("GetUserDetails")]
        public IActionResult GetUserDetails(string email)
        {
           
            return Ok(_loginBusiness.GetUserDetails(email));
        }

        [HttpPost]
        [Route("AddUserDetails")]
        public IActionResult AddUserDetails(Guid userId,long mobile)
        {
            _loginBusiness.AddUserDetails(userId, mobile);

            return Ok(new { message = "done" });
        }




    }
}
