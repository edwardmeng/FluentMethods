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
        public void StartOfMonth()
        {
            DateTime @this = DateTime.Now;
            DateTime value = @this.StartOfMonth(); // value = "yyyy/MM/01 00:00:00:000";
            Assert.Equal(new DateTime(value.Year, value.Month, 1), value);
        }
    }
}
