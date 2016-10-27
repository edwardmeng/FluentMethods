using System;

namespace FluentMethods.UnitTests
{
    public partial class TArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Union()
        {
            var array = new[] { "Fizz", "Buzz" };
            array = array.Union(new[] { "Buzz", "Foo" });
            Assert.Equal(3, array.Length);
            Assert.Equal("Foo", array.GetValue(2));
        }
    }
}
