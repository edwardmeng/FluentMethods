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
            Assert.Equal("FizzClass", typeof(DescriptionClass).GetDescription());
            Assert.Null(typeof(DisplayAnnotationClass).GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetMethodDescription()
        {
            Assert.Equal("FizzMethod", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetDescription());
            Assert.Equal("FizzMethod", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetPropertyDescription()
        {
            Assert.Equal("FizzProperty", typeof(DescriptionClass).GetProperty("DescriptionProperty").GetDescription());
            Assert.Equal("FizzProperty", typeof(DisplayAnnotationClass).GetProperty("DisplayProperty").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetProperty("DisplayNameProperty").GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetEventDescription()
        {
            Assert.Equal("FizzEvent", typeof(DescriptionClass).GetEvent("DescriptionEvent").GetDescription());
            Assert.Null(typeof(DisplayAnnotationClass).GetEvent("DisplayEvent").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetEvent("DisplayNameEvent").GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetFieldDescription()
        {
            Assert.Equal("FizzField", typeof(DescriptionClass).GetField("DescriptionField").GetDescription());
            Assert.Equal("FizzField", typeof(DisplayAnnotationClass).GetField("DisplayField").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetField("DisplayNameField").GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetIndexerDescription()
        {
            Assert.Equal("FizzIndexer", typeof(DescriptionClass).GetProperty("Item").GetDescription());
            Assert.Equal("FizzIndexer", typeof(DisplayAnnotationClass).GetProperty("Item").GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetProperty("Item").GetDescription());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetParameterDescription()
        {
            Assert.Equal("FizzParameter", typeof(DescriptionClass).GetMethod("DescriptionMethod").GetParameters()[0].GetDescription());
            Assert.Equal("FizzParameter", typeof(DisplayAnnotationClass).GetMethod("DisplayMethod").GetParameters()[0].GetDescription());
            Assert.Null(typeof(DisplayNameClass).GetMethod("DisplayNameMethod").GetParameters()[0].GetDescription());
        }
    }
}
