
namespace FluentMethods.UnitTests
{
    public partial class ControlFixture
    {
#if Net35
        [NUnit.Framework.Test]
        public void ToggleCssClass()
        {
            const string pageUrl = "/ModifyCssClass.aspx";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?action=toggle&class=control-label%20in"));
            Assert.Equal("text-info open control-label", doc.GetElementbyId("labelValue").GetAttributeValue("class", string.Empty));
            Assert.Equal("text-info open control-label", doc.GetElementbyId("textValue").GetAttributeValue("class", string.Empty));
        }
#else
        [NUnit.Framework.Test]
        public async System.Threading.Tasks.Task ToggleCssClass()
        {
            const string pageUrl = "/ModifyCssClass.aspx";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?action=toggle&class=control-label%20in"));
            Assert.Equal("text-info open control-label", doc.GetElementbyId("labelValue").GetAttributeValue("class", string.Empty));
            Assert.Equal("text-info open control-label", doc.GetElementbyId("textValue").GetAttributeValue("class", string.Empty));
        }
#endif
    }
}
