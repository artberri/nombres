using System.Globalization;

namespace Names.Web.Helpers
{
    public static class NameHelper
    {
        const int fontMin = 10;
        const int fontMax = 42;

        public static string GetStyle(int total, int max, int min)
        {
            double size;

            if (total <= min)
            {
                size = (double)fontMin;
            }
            else if (total >= max)
            {
                size = (double)fontMax;
            }
            else {
                size = ((double)total / (double)max) * (fontMax - fontMin) + fontMin;
            }

            return $"font-size:{size.ToString(CultureInfo.InvariantCulture)}px";
        }
    }
}
