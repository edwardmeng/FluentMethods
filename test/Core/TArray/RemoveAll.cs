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
        public void RemoveAll()
        {
            var array = new[] { "Fizz", "Buzz" };
            array = array.RemoveAll(x => x == "Fizz");
            Assert.Equal(1, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }
    }
}
