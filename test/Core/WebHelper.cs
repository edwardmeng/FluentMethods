using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FluentMethods.UnitTests
{
    public static class WebHelper
    {
        public const string SiteAddress = "http://localhost/FluentMethods.WebApp.net45";
        public static async Task<string> ProcessWebRequest(string url, Action<WebRequest> preparation)
        {
            var request = WebRequest.Create(url);
            preparation(request);
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            if (stream == null) return null;
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static Task<string> ProcessWebRequest(string url)
        {
            return ProcessWebRequest(url, request => { });
        }
    }
}
