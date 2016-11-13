using System.Reflection;

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
#if NetCore
            Assert.Equal("BuzzClass", typeof(DisplayNameClass).GetTypeInfo().GetDisplayName());
            Assert.Equal("DisplayAnnotationClass", typeof(DisplayAnnotationClass).GetTypeInfo().GetDisplayName());
#else
            Assert.Equal("BuzzClass", typeof(DisplayNameClass).GetDisplayName());
#if !Net35
            Assert.Equal("DisplayAnnotationClass", typeof(DisplayAnnotationClass).GetDisplayName());
#endif
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetPropertyDisplayName()
        {
#if NetCore
            Assert.Equal("DescriptionProperty", typeof(DescriptionClass).GetTypeInfo().GetProperty("DescriptionProperty").GetDisplayName());
            Assert.Equal("BuzzProperty", typeof(DisplayAnnotationClass).GetTypeInfo().GetProperty("DisplayProperty").GetDisplayName());
            Assert.Equal("BuzzProperty", typeof(DisplayNameClass).GetTypeInfo().GetProperty("DisplayNameProperty").GetDisplayName());
#else
            Assert.Equal("DescriptionProperty", typeof(DescriptionClass).GetProperty("DescriptionProperty").GetDisplayName());
#if !Net35
            Assert.Equal("BuzzProperty", typeof(DisplayAnnotationClass).GetProperty("DisplayProperty").GetDisplayName());
#endif
            Assert.Equal("BuzzProperty", typeof(DisplayNameClass).GetProperty("DisplayNameProperty").GetDisplayName());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetEventDisplayName()
        {
#if NetCore
            Assert.Equal("DescriptionEvent", typeof(DescriptionClass).GetTypeInfo().GetEvent("DescriptionEvent").GetDisplayName());
            Assert.Equal("DisplayEvent", typeof(DisplayAnnotationClass).GetTypeInfo().GetEvent("DisplayEvent").GetDisplayName());
            Assert.Equal("BuzzEvent", typeof(DisplayNameClass).GetTypeInfo().GetEvent("DisplayNameEvent").GetDisplayName());
#else
            Assert.Equal("DescriptionEvent", typeof(DescriptionClass).GetEvent("DescriptionEvent").GetDisplayName());
#if !Net35
            Assert.Equal("DisplayEvent", typeof(DisplayAnnotationClass).GetEvent("DisplayEvent").GetDisplayName());
#endif
            Assert.Equal("BuzzEvent", typeof(DisplayNameClass).GetEvent("DisplayNameEvent").GetDisplayName());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetFieldDisplayName()
        {
#if NetCore
            Assert.Equal("DescriptionField", typeof(DescriptionClass).GetTypeInfo().GetField("DescriptionField").GetDisplayName());
            Assert.Equal("BuzzField", typeof(DisplayAnnotationClass).GetTypeInfo().GetField("DisplayField").GetDisplayName());
            Assert.Equal("DisplayNameField", typeof(DisplayNameClass).GetTypeInfo().GetField("DisplayNameField").GetDisplayName());
#else
            Assert.Equal("DescriptionField", typeof(DescriptionClass).GetField("DescriptionField").GetDisplayName());
#if !Net35
            Assert.Equal("BuzzField", typeof(DisplayAnnotationClass).GetField("DisplayField").GetDisplayName());
#endif
            Assert.Equal("DisplayNameField", typeof(DisplayNameClass).GetField("DisplayNameField").GetDisplayName());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetIndexerDisplayName()
        {
#if NetCore
            Assert.Equal("Item", typeof(DescriptionClass).GetTypeInfo().GetProperty("Item").GetDisplayName());
            Assert.Equal("BuzzIndexer", typeof(DisplayAnnotationClass).GetTypeInfo().GetProperty("Item").GetDisplayName());
            Assert.Equal("BuzzIndexer", typeof(DisplayNameClass).GetTypeInfo().GetProperty("Item").GetDisplayName());
#else
            Assert.Equal("Item", typeof(DescriptionClass).GetProperty("Item").GetDisplayName());
#if !Net35
            Assert.Equal("BuzzIndexer", typeof(DisplayAnnotationClass).GetProperty("Item").GetDisplayName());
#endif
            Assert.Equal("BuzzIndexer", typeof(DisplayNameClass).GetProperty("Item").GetDisplayName());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetParameterDisplayName()
        {
#if NetCore
            Assert.Equal("x", typeof(DescriptionClass).GetTypeInfo().GetMethod("DescriptionMethod").GetParameters()[0].GetDisplayName());
            Assert.Equal("BuzzParameter", typeof(DisplayAnnotationClass).GetTypeInfo().GetMethod("DisplayMethod").GetParameters()[0].GetDisplayName());
            Assert.Equal("x", typeof(DisplayNameClass).GetTypeInfo().GetMethod("DisplayNameMethod").GetParameters()[0].GetDisplayName());
#else
            Assert.Equal("x", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetParameters()[0].GetDisplayName());
#if !Net35
            Assert.Equal("BuzzParameter", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetParameters()[0].GetDisplayName());
#endif
            Assert.Equal("x", typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetParameters()[0].GetDisplayName());
#endif
        }
    }
}
