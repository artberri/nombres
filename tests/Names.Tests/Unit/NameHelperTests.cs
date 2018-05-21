using Xunit;
using System;
using Names.Web.Helpers;

namespace Names.Tests.Unit
{
    public class NameHelperTests
    {
        [Theory]
        [InlineData(5, 3, 2, "font-size:42px")]
        [InlineData(1, 3, 2, "font-size:10px")]
        [InlineData(8, 10, 5, "font-size:35.6px")]
        public void NormalizeQuantities_WhenQuantityTypeTotal_ReturnsArrayOfTenTotalInts(int total, int max, int min, string expected)
        {
            var result = NameHelper.GetStyle(total, max, min);

            Assert.Equal(expected, result);
        }
    }
}
