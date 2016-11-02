namespace FluentMethods.UnitTests
{
    public partial class CustomAttributeProviderFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetClassDisplayName()
        {
            Assert.Equal("BuzzClass", typeof(DisplayNameClass).GetDisplayName());
            Assert.Equal("DisplayAnnotationClass", typeof(DisplayAnnotationClass).GetDisplayName());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetPropertyDisplayName()
        {
            Assert.Equal("DescriptionProperty", typeof(DescriptionClass).GetProperty("DescriptionProperty").GetDisplayName());
            Assert.Equal("BuzzProperty", typeof(DisplayAnnotationClass).GetProperty("DisplayProperty").GetDisplayName());
            Assert.Equal("BuzzProperty", typeof(DisplayNameClass).GetProperty("DisplayNameProperty").GetDisplayName());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetEventDisplayName()
        {
            Assert.Equal("DescriptionEvent", typeof(DescriptionClass).GetEvent("DescriptionEvent").GetDisplayName());
            Assert.Equal("DisplayEvent", typeof(DisplayAnnotationClass).GetEvent("DisplayEvent").GetDisplayName());
            Assert.Equal("BuzzEvent", typeof(DisplayNameClass).GetEvent("DisplayNameEvent").GetDisplayName());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetFieldDisplayName()
        {
            Assert.Equal("DescriptionField", typeof(DescriptionClass).GetField("DescriptionField").GetDisplayName());
            Assert.Equal("BuzzField", typeof(DisplayAnnotationClass).GetField("DisplayField").GetDisplayName());
            Assert.Equal("DisplayNameField", typeof(DisplayNameClass).GetField("DisplayNameField").GetDisplayName());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetIndexerDisplayName()
        {
            Assert.Equal("Item", typeof(DescriptionClass).GetProperty("Item").GetDisplayName());
            Assert.Equal("BuzzIndexer", typeof(DisplayAnnotationClass).GetProperty("Item").GetDisplayName());
            Assert.Equal("BuzzIndexer", typeof(DisplayNameClass).GetProperty("Item").GetDisplayName());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetParameterDisplayName()
        {
            Assert.Equal("x", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetParameters()[0].GetDisplayName());
            Assert.Equal("BuzzParameter", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetParameters()[0].GetDisplayName());
            Assert.Equal("x", typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetParameters()[0].GetDisplayName());
        }
    }
}
