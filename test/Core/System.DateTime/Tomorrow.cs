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
        public void Tomorrow()
        {
            DateTime @this = DateTime.Now;
            DateTime result = @this.Tomorrow(); // Return date as tomorrow
            Assert.Equal(@this.AddDays(1).Day, result.Day);
        }
    }
}
