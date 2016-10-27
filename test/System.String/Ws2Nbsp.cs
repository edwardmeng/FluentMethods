using System;

namespace FluentMethods.UnitTests
{
    public partial class StringFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Ws2Nbsp()
        {
            Assert.Equal("Fizz&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Buzz", "Fizz\t Buzz".Ws2Nbsp());
            Assert.Equal("Fizz&nbsp;Buzz", "Fizz Buzz".Ws2Nbsp());
        }
    }
}
