using BookYourMealAPI.CustomExceptions;
using BookYourMealAPI.DataAccess.Services;
using BookYourMealAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BookYourMeal.Tests.AddClass;

namespace BookYourMeal.Tests
{
    [TestClass]
    public class AdminDATest
    {

        [TestMethod]
        public async Task DisableCustomer_ShouldDisableCustomer_Happy()
        {

            TblUserDetails tblUserDetails = new TblUserDetails();

            // arrange
            var mockSet = new Mock<DbSet<TblUserDetails>>();
            mockSet.Setup(m => m.Find(It.IsAny<Guid>())).Returns(tblUserDetails);
           

            

            var mockContext = new Mock<Orchard8Context>();
            mockContext.Setup(m => m.TblUserDetails).Returns(mockSet.Object);
            var service = new AdminDA(mockContext.Object);
            
            Guid id = new Guid("882F14BC-E598-4C59-8DFA-2AC6E47DD42D");
            await service.DisableCustomer(id);
            mockSet.Verify(m => m.Find(It.IsAny<Guid>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

   


        [TestMethod]
        public async Task DisableRestaurent_ShouldDisableRestaurent_Happy()
        {

            TblUserDetails tblUserDetails = new TblUserDetails();

            // arrange
            var mockSet = new Mock<DbSet<TblUserDetails>>();
            mockSet.Setup(m => m.Find(It.IsAny<Guid>())).Returns(tblUserDetails);
            



            var mockContext = new Mock<Orchard8Context>();
            mockContext.Setup(m => m.TblUserDetails).Returns(mockSet.Object);
            var service = new AdminDA(mockContext.Object);

            Guid id = new Guid("46616623-17C5-4BDF-842D-102B845D236D");
            await service.DisableRestaurent(id);
            mockSet.Verify(m => m.Find(It.IsAny<Guid>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());



        }
        [TestMethod]
        public async Task DeleteRestaurant_ShouldDeleteRestaurant_Happy()
        {

            TblRestaurantDetails tblRestaurantDetails = new TblRestaurantDetails();

            // arrange
            var mockSet = new Mock<DbSet<TblRestaurantDetails>>();
            mockSet.Setup(m => m.Find(It.IsAny<Guid>())).Returns(tblRestaurantDetails);



            var mockContext = new Mock<Orchard8Context>();
            mockContext.Setup(m => m.TblRestaurantDetails).Returns(mockSet.Object);
            var service = new AdminDA(mockContext.Object);
            Guid id = Guid.NewGuid();
            await service.DeleteRestaurant(id);
            mockSet.Verify(m => m.Find(It.IsAny<Guid>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());



        }
        [TestMethod]
        public async Task GetAllUsers_ShouldReturnListOfallUsers_Happy()
        {

            var data = new List<TblUserDetails>()
            {



                new TblUserDetails
                {

                },
                new TblUserDetails
                {

                }
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblUserDetails>>();
            mockDbSet.As<IAsyncEnumerable<TblUserDetails>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblUserDetails>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblUserDetails>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblUserDetails>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblUserDetails>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblUserDetails>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblUserDetails).Returns(mockDbSet.Object);
            var service = new AdminDA(mockCtx.Object);
            var expectedlist = await service.GetAllUsers();
            Assert.AreEqual(2, expectedlist.Count);
        }


        [TestMethod]
        public async Task GetOrdersList_ShouldReturnListOfallOrders_Happy()
        {

            var data = new List<TblOrder>()
            {



                new TblOrder
                {

                },
                new TblOrder
                {

                }
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblOrder>>();
            mockDbSet.As<IAsyncEnumerable<TblOrder>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblOrder>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblOrder>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblOrder>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblOrder>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblOrder>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblOrder).Returns(mockDbSet.Object);
            var service = new AdminDA(mockCtx.Object);
            var expectedlist = await service.GetOrdersList();
            Assert.AreEqual(2, expectedlist.Count);
        }
        [TestMethod]
        public async Task GetAllRestaurantItem_ShouldReturnListOfallRestaurantItem_Happy()
        {
            Guid restaurantId = Guid.NewGuid();

            var data = new List<TblItemDetails>()
            {



                new TblItemDetails
                {

                },
                new TblItemDetails
                {

                }
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblItemDetails>>();
            mockDbSet.As<IAsyncEnumerable<TblItemDetails>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblItemDetails>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblItemDetails>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblItemDetails>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblItemDetails>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblItemDetails>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblItemDetails).Returns(mockDbSet.Object);
            var service = new AdminDA(mockCtx.Object);
            var expectedlist = await service.GetAllRestaurantItems(restaurantId);
            Assert.AreEqual(2, expectedlist.Count);
        }

        
    }
}
       
       
     
 

