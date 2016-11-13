using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public void GetCustomAttribute()
        {
#if NetCore
            Assert.NotNull(typeof(DescriptionClass).GetTypeInfo().GetCustomAttribute<DescriptionAttribute>());
            Assert.Null(typeof(DescriptionClass).GetTypeInfo().GetCustomAttribute<DisplayNameAttribute>());
#else
            Assert.NotNull(typeof(DescriptionClass).GetCustomAttribute<DescriptionAttribute>());
            Assert.Null(typeof(DescriptionClass).GetCustomAttribute<DisplayNameAttribute>());
#endif

            Assert.Throws<AmbiguousMatchException>(()=> typeof(DescriptionClass).GetProperty("DescriptionProperty").GetCustomAttribute<ValidationAttribute>());
        }
    }
}
