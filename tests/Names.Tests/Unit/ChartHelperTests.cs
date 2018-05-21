using Xunit;
using System;
using Names.Web.Helpers;
using Names.Domain.Entities;
using Names.Web.Enums;

namespace Names.Tests.Unit
{
    public class ChartHelperTests
    {
        [Fact]
        public void NormalizeQuantities_WhenQuantityTypeTotal_ReturnsArrayOfTenTotalInts()
        {
            var result = ChartHelper.NormalizeQuantities(new Quantity[]{
                new Quantity{
                    Year = 1,
                    Total = 10,
                    Percentage = 0.5F
                },
                new Quantity{
                    Year = 2,
                    Total = 20,
                    Percentage = 1.5F
                },
                new Quantity{
                    Year = 3,
                    Total = 5,
                    Percentage = 2.5F
                },
                new Quantity{
                    Year = 5,
                    Total = 5,
                    Percentage = 4.5F
                },
                new Quantity{
                    Year = 6,
                    Total = 5,
                    Percentage = 2.5F
                },
                new Quantity{
                    Year = 9,
                    Total = 5,
                    Percentage = 1.5F
                }
            }, QuantityType.Total);

            Assert.Equal(result, new int[]{10, 20, 5, 0, 5, 5, 0, 0, 5, 0});
        }

        [Fact]
        public void NormalizeQuantities_WhenQuantityTypePercentage_ReturnsArrayOfTenPercentageInts()
        {
            var result = ChartHelper.NormalizeQuantities(new Quantity[]{
                new Quantity{
                    Year = 1,
                    Total = 10,
                    Percentage = 0.5F
                },
                new Quantity{
                    Year = 2,
                    Total = 20,
                    Percentage = 1.5F
                },
                new Quantity{
                    Year = 3,
                    Total = 5,
                    Percentage = 2.2F
                },
                new Quantity{
                    Year = 5,
                    Total = 5,
                    Percentage = 4.7F
                },
                new Quantity{
                    Year = 6,
                    Total = 5,
                    Percentage = 2.5F
                },
                new Quantity{
                    Year = 9,
                    Total = 5,
                    Percentage = 1.5F
                }
            }, QuantityType.Percentage);

            Assert.Equal(result, new int[]{0, 1, 2, 0, 4, 2, 0, 0, 1, 0});
        }
    }
}
