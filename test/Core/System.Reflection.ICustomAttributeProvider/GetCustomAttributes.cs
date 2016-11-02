using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public void GetCustomAttributes()
        {
            var property = typeof(DescriptionClass).GetProperty("DescriptionProperty");
            Assert.Equal(3, property.GetCustomAttributes().ToArray().Length);
            Assert.Equal(2, property.GetCustomAttributes<ValidationAttribute>().ToArray().Length);
        }
    }
}
