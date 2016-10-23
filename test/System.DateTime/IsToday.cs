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
        public void IsToday()
        {
            DateTime @thisToday = DateTime.Today;
            DateTime @thisYesterday = @thisToday.AddDays(-1);
            bool result1 = @thisToday.IsToday(); // return true;
            bool result2 = @thisYesterday.IsToday(); // return false;
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
