using System;
using System.Net;

namespace FluentMethods.UnitTests
{
    public partial class HttpRequestFixture
    {
#if Net35
        [NUnit.Framework.Test]
        public void GetRequiredParameter()
        {
            const string pageUrl = "/GetRequiredParameter.aspx", alterPageUrl = "/GetRequiredParameter";
            Func<string, string> findValue = html =>
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                return doc.GetElementbyId("labelValue").InnerText;
            };
            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value=Fizz"));
            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}"));
            var guid = Guid.NewGuid().ToString();
            Assert.Equal(guid, findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value={guid}")));


            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/Fizz"));
            Assert.Equal(guid, findValue(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/{guid}")));
            Assert.Throws<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}"));
        }
#else
        [NUnit.Framework.Test]
        public async System.Threading.Tasks.Task GetRequiredParameter()
        {
            const string pageUrl = "/GetRequiredParameter.aspx", alterPageUrl = "/GetRequiredParameter";
            Func<string, string> findValue = html =>
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                return doc.GetElementbyId("labelValue").InnerText;
            };
            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value=Fizz"));
            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}"));
            var guid = Guid.NewGuid().ToString();
            Assert.Equal(guid, findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?value={guid}")));


            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/Fizz"));
            Assert.Equal(guid, findValue(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}/{guid}")));
            await Assert.ThrowsAsync<WebException>(() => WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{alterPageUrl}"));
        }
#endif
    }
}
