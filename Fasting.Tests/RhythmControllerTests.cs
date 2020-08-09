using Fasting.Controllers;
using Fasting.Data;
using Fasting.Models;
using Fasting.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fasting.Tests
{
    public class RhythmControllerTests
    {
        RhythmController underTest;
        ApplicationDbContext context;
        IAchievedItemService achievedItemService;

        public RhythmControllerTests()
        {
            underTest = new RhythmController(context, achievedItemService);
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
            var expectedModel = new List<Rhythm>();
            var expectedModelType = expectedModel.GetType();

            var expectedType = context.Rhythm.GetType();
            Assert.Equal(expectedModelType, expectedType);
            
        }
    }
}
