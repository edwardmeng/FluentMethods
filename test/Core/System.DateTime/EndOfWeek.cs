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
        public void EndOfWeek()
        {
            var @this = new DateTime(2014, 04, 16);
            DateTime value = @this.EndOfWeek(); // value = "2013/04/13 23:59:59:999";
            Assert.Equal(new DateTime(2014, 04, 19, 23, 59, 59, 999), value);
        }
    }
}
