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
        public void IsAfternoon()
        {
            var @thisMorning = new DateTime(2014, 04, 12, 8, 0, 0);
            var @thisAfternoon = new DateTime(2014, 04, 12, 17, 0, 0);
            bool result1 = @thisMorning.IsAfternoon(); // return false;
            bool result2 = @thisAfternoon.IsAfternoon(); // return true;
            Assert.False(result1);
            Assert.True(result2);
        }
    }
}
