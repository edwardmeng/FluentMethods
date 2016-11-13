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
        public void GetClassDescription()
        {
#if NetCore
            Assert.Equal("FizzClass", typeof(DescriptionClass).GetTypeInfo().GetDescription());
            Assert.Null(typeof(DisplayAnnotationClass).GetTypeInfo().GetDescription());
#else
            Assert.Equal("FizzClass", typeof(DescriptionClass).GetDescription());
#if !Net35
            Assert.Null(typeof(DisplayAnnotationClass).GetDescription());
#endif
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetMethodDescription()
        {
#if NetCore
            Assert.Equal("FizzMethod", typeof(DescriptionClass).GetTypeInfo().GetMethod("DescriptionMethod").GetDescription());
            Assert.Equal("FizzMethod", typeof(DisplayAnnotationClass).GetTypeInfo().GetMethod("DisplayMethod").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetMethod("DisplayNameMethod").GetDescription());
#else
            Assert.Equal("FizzMethod", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetDescription());
#if !Net35
            Assert.Equal("FizzMethod", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetDescription());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetPropertyDescription()
        {
#if NetCore
            Assert.Equal("FizzProperty", typeof(DescriptionClass).GetTypeInfo().GetProperty("DescriptionProperty").GetDescription());
            Assert.Equal("FizzProperty", typeof(DisplayAnnotationClass).GetTypeInfo().GetProperty("DisplayProperty").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetProperty("DisplayNameProperty").GetDescription());
#else
            Assert.Equal("FizzProperty", typeof(DescriptionClass).GetProperty("DescriptionProperty").GetDescription());
#if !Net35
            Assert.Equal("FizzProperty", typeof(DisplayAnnotationClass).GetProperty("DisplayProperty").GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetProperty("DisplayNameProperty").GetDescription());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetEventDescription()
        {
#if NetCore
            Assert.Equal("FizzEvent", typeof(DescriptionClass).GetTypeInfo().GetEvent("DescriptionEvent").GetDescription());
            Assert.Null(typeof(DisplayAnnotationClass).GetTypeInfo().GetEvent("DisplayEvent").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetEvent("DisplayNameEvent").GetDescription());
#else
            Assert.Equal("FizzEvent", typeof(DescriptionClass).GetEvent("DescriptionEvent").GetDescription());
#if !Net35
            Assert.Null(typeof(DisplayAnnotationClass).GetEvent("DisplayEvent").GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetEvent("DisplayNameEvent").GetDescription());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetFieldDescription()
        {
#if NetCore
            Assert.Equal("FizzField", typeof(DescriptionClass).GetTypeInfo().GetField("DescriptionField").GetDescription());
            Assert.Equal("FizzField", typeof(DisplayAnnotationClass).GetTypeInfo().GetField("DisplayField").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetField("DisplayNameField").GetDescription());
#else
            Assert.Equal("FizzField", typeof(DescriptionClass).GetField("DescriptionField").GetDescription());
#if !Net35
            Assert.Equal("FizzField", typeof(DisplayAnnotationClass).GetField("DisplayField").GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetField("DisplayNameField").GetDescription());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetIndexerDescription()
        {
#if NetCore
            Assert.Equal("FizzIndexer", typeof(DescriptionClass).GetTypeInfo().GetProperty("Item").GetDescription());
            Assert.Equal("FizzIndexer", typeof(DisplayAnnotationClass).GetTypeInfo().GetProperty("Item").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetProperty("Item").GetDescription());
#else
            Assert.Equal("FizzIndexer", typeof(DescriptionClass).GetProperty("Item").GetDescription());
#if !Net35
            Assert.Equal("FizzIndexer", typeof(DisplayAnnotationClass).GetProperty("Item").GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetProperty("Item").GetDescription());
#endif
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetParameterDescription()
        {
#if NetCore
            Assert.Equal("FizzParameter", typeof(DescriptionClass).GetTypeInfo().GetMethod("DescriptionMethod").GetParameters()[0].GetDescription());
            Assert.Equal("FizzParameter", typeof(DisplayAnnotationClass).GetTypeInfo().GetMethod("DisplayMethod").GetParameters()[0].GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetTypeInfo().GetMethod("DisplayNameMethod").GetParameters()[0].GetDescription());
#else
            Assert.Equal("FizzParameter", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetParameters()[0].GetDescription());
#if !Net35
            Assert.Equal("FizzParameter", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetParameters()[0].GetDescription());
#endif
            Assert.Null(typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetParameters()[0].GetDescription());
#endif
        }
    }
}
