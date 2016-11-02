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
        public void StartOfYear()
        {
            DateTime @this = DateTime.Now;
            DateTime value = @this.StartOfYear(); // value = "yyyy/01/01 00:00:00:000";
            Assert.Equal(new DateTime(value.Year, 1, 1), value);
        }
    }
}
