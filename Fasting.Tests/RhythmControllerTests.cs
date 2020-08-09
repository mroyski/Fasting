using Fasting.Controllers;
using Fasting.Data;
using Fasting.Models;
using Fasting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fasting.Tests
{
    public class RhythmControllerTests
    {
        RhythmController underTest;
        private ApplicationDbContext mockContext;
        private IAchievedItemService achievedItemService;

        public RhythmControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            mockContext = new ApplicationDbContext(options);
            achievedItemService = new AchievedItemService(mockContext);

            underTest = new RhythmController(mockContext, achievedItemService);
        }

        [Fact]
        public void Index_Returns_ViewResult()
        {
            var result = underTest.Index();
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void Index_Model_Is_Expected_Model()
        {
            var expectedModel = new List<Rhythm>().GetType();
            var existingModel = mockContext.Rhythm.ToList().GetType();
            Assert.Equal(expectedModel, existingModel);
        }

        [Fact]
        public void MarkDone_Changes_False_Achieved_Property_To_True()
        {
            var newItem = new Rhythm() { Id = 1, Achieved = false };
            mockContext.Rhythm.Add(newItem);
            mockContext.SaveChanges();

            var result = (achievedItemService.MarkDoneAsync(newItem.Id)).Result;
           
            Assert.True(result);
        }

        [Fact]
        public void MarkDone_Changes_True_Achieved_Property_To_False()
        {
            var newItem = new Rhythm() { Id = 1, Achieved = true };
            mockContext.Rhythm.Add(newItem);
            mockContext.SaveChanges();

            var result = (achievedItemService.MarkDoneAsync(newItem.Id)).Result;

            Assert.False(result);
        }
    }
}
