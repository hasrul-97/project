using BookYourMealAPI.Business.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookYourMealAPI.BookYourMealAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllAllowPolicy")]
   
    public class AuthController : Controller
    {
        //private IConfiguration _config;
        private readonly ILoginBll _loginBusiness;
        [ExcludeFromCodeCoverage]
        public AuthController(ILoginBll loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

     

        [HttpPost]
        [Route("GetToken")]
        [ExcludeFromCodeCoverage]
        public IActionResult GenerateJSONWebToken(TblUserDetails userDetails)
        {
            UserDetails userDetail = _loginBusiness.GetUserDetails(userDetails.Email);

            List<Claim> claim = new List<Claim>
             {
                new Claim(ClaimTypes.Name,userDetail.UserId.ToString()),
               new Claim(ClaimTypes.Role,userDetail.RoleName)
             };


            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfghjkjhgfzasdfghjk"));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:44388",
                audience: "https://localhost:4200",
              claims: claim,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
            var key = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = key });
        }
    }  
}

