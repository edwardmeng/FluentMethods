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
        public void IsMorning()
        {
            var @thisMorning = new DateTime(2014, 04, 12, 8, 0, 0);
            var @thisAfternoon = new DateTime(2014, 04, 12, 17, 0, 0);
            bool result1 = @thisMorning.IsMorning(); // return true;
            bool result2 = @thisAfternoon.IsMorning(); // return false;
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
