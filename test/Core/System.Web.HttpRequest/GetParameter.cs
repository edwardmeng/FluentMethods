using System;
using System.Net;

namespace FluentMethods.UnitTests
{
    public partial class HttpRequestFixture
    {
#if Net35
        [NUnit.Framework.Test]
        public void GetParameter()
        {
            const string pageUrl = "/GetParameter.aspx", alterPageUrl = "/GetParameter";
            Func<string, string> findValue = html =>
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                return doc.GetElementbyId("labelValue").InnerText;
            };
            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value=Fizz"));
            Assert.Equal(Guid.Empty.ToString(), findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}")));
            var guid = Guid.NewGuid().ToString();
            Assert.Equal(guid, findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value={guid}")));

            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/Fizz"));
            Assert.Equal(guid, findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/{guid}")));
            Assert.Equal(Guid.Empty.ToString(), findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}")));
        }
#else
        [NUnit.Framework.Test]
        public async System.Threading.Tasks.Task GetParameter()
        {
            const string pageUrl = "/GetParameter.aspx", alterPageUrl= "/GetParameter";
            Func<string, string> findValue = html =>
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                return doc.GetElementbyId("labelValue").InnerText;
            };
            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value=Fizz"));
            Assert.Equal(Guid.Empty.ToString(), findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}")));
            var guid = Guid.NewGuid().ToString();
            Assert.Equal(guid, findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value={guid}")));

            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/Fizz"));
            Assert.Equal(guid, findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/{guid}")));
            Assert.Equal(Guid.Empty.ToString(), findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}")));
        }
#endif
    }
}
