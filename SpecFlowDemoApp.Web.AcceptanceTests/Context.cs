using System.Collections.Generic;

namespace SpecFlowDemoApp.Web.AcceptanceTests
{
    internal class Context
    {
        public static Dictionary<string, string> PageNameUrlMap = new Dictionary<string, string>
        {
            {"Login", "http://localhost:9876/authentication/login"},
            {"Home", "http://localhost:9876/"}
        };
    }
}