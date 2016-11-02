using System;
using System.Net;
using System.Threading.Tasks;

namespace FluentMethods.UnitTests
{
    public partial class HttpRequestFixture
    {
        [NUnit.Framework.Test]
        public async Task GetRequiredParameter()
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
    }
}
