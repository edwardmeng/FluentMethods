using System.Threading.Tasks;

namespace FluentMethods.UnitTests
{
    public partial class ControlFixture
    {
        [NUnit.Framework.Test]
        public async Task AddCssClass()
        {
            const string pageUrl = "/ModifyCssClass.aspx";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(await WebHelper.ProcessWebRequest($"{WebHelper.SiteAddress}{pageUrl}?action=add&class=control-label%20in"));
            Assert.Equal("text-info open in control-label", doc.GetElementbyId("labelValue").GetAttributeValue("class", string.Empty));
            Assert.Equal("text-info open in control-label", doc.GetElementbyId("textValue").GetAttributeValue("class", string.Empty));
        }
    }
}
