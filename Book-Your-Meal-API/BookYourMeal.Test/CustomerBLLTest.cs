using BookYourMealAPI.Business.Services;
using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Repositories;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookYourMeal.Tests
{
    [TestClass]
    public class CustomerBLLTest
    {

        [TestMethod]
        public void EditProfile_ShouldEditProfile_Sad()
        {
            Guid userid = Guid.NewGuid();
            TblUserDetails user = new TblUserDetails();
            //Arrange
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.EditProfile(userid, user)).Throws(new AllException(""));
            CustomerBll orderBll = new CustomerBll(mock.Object);

            //Act
            //Assert
            Assert.ThrowsException<AllException>(() => orderBll.EditProfile(userid, user));

        }

        [TestMethod]
        public void FilteredItems_ShouldFilterItems_Happy()
        {
            Guid userid = Guid.NewGuid();
            Filter filter = new Filter();
            List<ItemRequiredDetails> list = new List<ItemRequiredDetails>();
            //Arrange
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetAllItemDetails(filter)).Returns(list);
            CustomerBll orderBll = new CustomerBll(mock.Object);

            //Act
            //  List<ItemRequiredDetails> myList = orderBll.FilteredItems(userid,filter);
            //Assert
            Assert.ThrowsException<AllException>(() => orderBll.FilteredItems(userid, filter));
        }

        [TestMethod]
        public void GetAlllBookmarkedRestaurants_ShouldReturnRestaurants_Happy()
        {
            Guid userid = Guid.NewGuid();
            List<BookmarkedRestaurant> list = new List<BookmarkedRestaurant>();
            //Arrange
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetAllBookMarkedRestaurent(userid)).Returns(list);
            CustomerBll orderBll = new CustomerBll(mock.Object);

            //Act
            List<BookmarkedRestaurant> myList = orderBll.GetAllBookMarkedRestaurent(userid);
            //Assert
            Assert.AreEqual(myList, list);
        }


        [TestMethod]
        public void GetAllRestaurent_ShouldGetAllRestaurenList_Sad()
        {
            //Arrange
            List<RestaurantDetails> list = new List<RestaurantDetails>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetAllRestaurent()).Throws(new AllException(""));
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            //Assert
            Assert.ThrowsException<AllException>(() => customerBLL.GetAllRestaurent());

        }
        
        [TestMethod]
        public void GetPastOrder_ShouldGetPastOrderList_Happy()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<PastOrderDetails> list = new List<PastOrderDetails>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetPastOrder(id)).Returns(list);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            List<PastOrderDetails> list1 = new List<PastOrderDetails>();
            list1 = customerBLL.GetPastOrder(id);
            //Assert
            Assert.AreEqual(list, list1);

        }

        
        [TestMethod]
        public void GetPastOrder_ShouldGetPastOrderList_Sad()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<PastOrderDetails> list = new List<PastOrderDetails>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetPastOrder(id)).Throws(new AllException(""));
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            //Assert
            Assert.ThrowsException<AllException>(() => customerBLL.GetPastOrder(id));

        }

        [TestMethod]
        public void GetAllRestaurantLoc_ShouldGetRestaurantList_Happy()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<RestaurantDetails> list = new List<RestaurantDetails>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            double value=1.0000;
            mock.Setup(x => x.GetAllRestaurentLoc(value,value)).Returns(list);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            List<RestaurantDetails> mylist = customerBLL.GetAllRestaurentLoc(value,value);
            //Assert
            Assert.AreEqual(mylist, list);

        }

        [TestMethod]
        public void GetProfileDetails_ShouldGetProfile_Happy()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            TblUserDetails obj = new TblUserDetails();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetProfileDetails(id)).Returns(obj);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            TblUserDetails myObj = customerBLL.GetProfileDetails(id);
            //Assert
            Assert.AreEqual(myObj,obj);
        }

        [TestMethod]
        public void GetRestaurantItemDetails_ShouldGetRestaurantItems_Happy()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<TblItemDetails> list = new List<TblItemDetails>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetResaturentItemDetails(id)).Returns(list);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            List<TblItemDetails> myObj = customerBLL.GetResaturentItemDetails(id);
            //Assert
            Assert.AreEqual(myObj, list);
        }

       
        [TestMethod]
        public void GetPastOrderItemDetails_ShouldGetPastOrderItemDetailsList_Happy()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<string> list = new List<string>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetPastOrderItemDetails(id)).Returns(list);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            List<string> list1 = new List<string>();
            list1 = customerBLL.GetPastOrderItemDetails(id);
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public void GetPastOrderItemDetails_ShouldGetPastOrderItemDetailsList_Sad()
        {
            //Arrange
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            List<string> list = new List<string>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.GetPastOrderItemDetails(id)).Throws(new AllException(""));
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            //Assert
            Assert.ThrowsException<AllException>(() => customerBLL.GetPastOrderItemDetails(id));

        }

        [TestMethod]
        public void Search_ShouldSearch_Happy()
        {
            //Arrange
            string str = null;
            List<string> list = new List<string>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.Search(str)).Returns(list);
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            List<string> list1 = new List<string>();
            list1 = customerBLL.Search(str);
            //Assert
            Assert.AreEqual(list, list1);

        }

        [TestMethod]
        public void Search_ShouldSearch_Sad()
        {
            //Arrange
            string str = null;
            List<string> list = new List<string>();
            Mock<ICustomerDA> mock = new Mock<ICustomerDA>();
            mock.Setup(x => x.Search(str)).Throws(new AllException(""));
            CustomerBll customerBLL = new CustomerBll(mock.Object);

            //Act
            //Assert
            Assert.ThrowsException<AllException>(() => customerBLL.Search(str));
        }
    }
}
