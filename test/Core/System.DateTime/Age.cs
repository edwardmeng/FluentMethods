using System;

namespace FluentMethods.UnitTests
{
    public partial class DateTimeFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Age()
        {
            var @this = new DateTime(1981, 01, 01);
            int result = @this.Age(); // result CurrentYear - 1981
            Assert.Equal(DateTime.Now.Year - 1981, result);

        }
    }
}
