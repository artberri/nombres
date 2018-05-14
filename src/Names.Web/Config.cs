using System;

namespace Names.Web
{
    public static class Config
    {
#if DEBUG
        public static string BaseUrl = "http://localhost:5000";
#else
        public static string BaseUrl = "";
#endif

    }
}
