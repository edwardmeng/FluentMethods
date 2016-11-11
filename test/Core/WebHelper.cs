using System;
using System.IO;
using System.Net;

namespace FluentMethods.UnitTests
{
    public static class WebHelper
    {
        public const string SiteAddress = "http://localhost/FluentMethods.WebApp.net45";

#if Net35
        public static string ProcessWebRequest(string url, Action<WebRequest> preparation)
        {
            var request = WebRequest.Create(url);
            preparation(request);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream == null) return null;
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string ProcessWebRequest(string url)
        {
            return ProcessWebRequest(url, request => { });
        }
#else
        public static async System.Threading.Tasks.Task<string> ProcessWebRequest(string url, Action<WebRequest> preparation)
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

        public static System.Threading.Tasks.Task<string> ProcessWebRequest(string url)
        {
            return ProcessWebRequest(url, request => { });
        }
#endif
    }
}
