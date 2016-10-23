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
        public void IsWeekDay()
        {
            var @thisFriday = new DateTime(2013, 11, 22); // Friday
            var @thisSaturday = new DateTime(2013, 11, 23); // Saturday
            bool value1 = @thisFriday.IsWeekDay(); // return true;
            bool value2 = @thisSaturday.IsWeekDay(); // return false;
            Assert.True(value1);
            Assert.False(value2);
        }
    }
}
