using System;
using Names.Domain.Entities;
using Names.Web.Enums;

namespace Names.Web.Helpers
{
    public static class ChartHelper
    {
        public static int[] NormalizeQuantities(Quantity[] quantities, QuantityType quantityType)
        {
            int[] data = new int[10];

            for (var i = 0; i < 10; i++)
            {
                var quantity = Array.Find(quantities, q => q.Year == i + 1);

                if (quantityType == QuantityType.Total)
                {
                    data[i] = quantity != null ? quantity.Total : 0;
                }
                else
                {
                    data[i] = quantity != null ? (int)quantity.Percentage : 0;
                }
            }

            return data;
        }
    }
}
