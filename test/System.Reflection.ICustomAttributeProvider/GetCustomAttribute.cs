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
            Assert.NotNull(typeof(DescriptionClass).GetCustomAttribute<DescriptionAttribute>());
            Assert.Null(typeof(DescriptionClass).GetCustomAttribute<DisplayNameAttribute>());

            Assert.Throws<AmbiguousMatchException>(()=> typeof(DescriptionClass).GetProperty("DescriptionProperty").GetCustomAttribute<ValidationAttribute>());
        }
    }
}
