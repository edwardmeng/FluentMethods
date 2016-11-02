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
        public void IsWeekend()
        {
            var @thisFriday = new DateTime(2013, 11, 22); // Friday
            var @thisSaturday = new DateTime(2013, 11, 23); // Saturday
            bool value1 = @thisFriday.IsWeekend(); // return false;
            bool value2 = @thisSaturday.IsWeekend(); // return true;
            Assert.False(value1);
            Assert.True(value2);
        }
    }
}
