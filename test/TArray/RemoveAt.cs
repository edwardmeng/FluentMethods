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
        public void RemoveAt()
        {
            var array = new[] { "Fizz" , "Buzz" };
            array = array.RemoveAt(0);
            Assert.Equal(1, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }
    }
}
