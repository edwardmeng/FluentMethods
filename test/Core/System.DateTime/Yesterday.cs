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
        public void Yesterday()
        {
            DateTime @this = DateTime.Now;
            DateTime result = @this.Yesterday(); // Return date as yesterday
            Assert.Equal(@this.AddDays(-1).Day, result.Day);
        }
    }
}
