using BookYourMealAPI.DataAccess.Services;
using BookYourMealAPI.Domain.Entities;
using BookYourMealAPI.Domain.Models;
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
    public class OrderDATest
    {
       
        [TestMethod]
        public void GetFavouriteRestaurant_ShouldReturnListOfallFavouriteRestaurant_Happy()
        {
            Guid Id =  new Guid("183B53A9 - B76F - 4977 - A94F - F3B5C83D1FF8");

            var data = new List<TblFavourite>()
            {



                new TblFavourite
                {

                }
               
               }.AsQueryable();
            var mockDbSet = new Mock<DbSet<TblFavourite>>();
            mockDbSet.As<IAsyncEnumerable<TblFavourite>>()
                .Setup(d => d.GetEnumerator())
                .Returns(new AsyncEnumerator<TblFavourite>(data.GetEnumerator()));



            mockDbSet.As<IQueryable<TblFavourite>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<TblFavourite>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<TblFavourite>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<TblFavourite>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockCtx = new Mock<Orchard8Context>();
            mockCtx.SetupGet(c => c.TblFavourite).Returns(mockDbSet.Object);
            var service = new OrderDA(mockCtx.Object);
            var expectedlist = service.GetFavouriteRestaurant(Id);
            Assert.AreEqual(1,expectedlist.Count);
        }
    }
}
