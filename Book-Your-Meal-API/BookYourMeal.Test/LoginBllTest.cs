using BookYourMealAPI.Business.Services;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourMeal.Tests
{
    [TestClass]
    public class LoginBllTest
    {
        [TestMethod]
        public void AddUser_ShouldAddUser_Happy()
        {
            //Arrange

            TblUserDetails tblUserDetails = new TblUserDetails();
            tblUserDetails.Email = "sss";
            Mock<ILoginDA> mock = new Mock<ILoginDA>();
            mock.Setup(x => x.AddUser(tblUserDetails)).Returns(1);
            LoginBll loginBll = new LoginBll(mock.Object);

       

            //Act
        int check =loginBll.AddUser(tblUserDetails);
        //Assert
        Assert.AreEqual(1,check);
        }
    }
}
