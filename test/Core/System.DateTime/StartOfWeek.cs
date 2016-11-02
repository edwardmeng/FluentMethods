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
        public void StartOfWeek()
        {
            var @this = new DateTime(2014, 04, 16);
            DateTime value = @this.StartOfWeek(); // value = "2013/04/13 00:00:00:000";
            Assert.Equal(new DateTime(2014, 04, 13), value);
        }
    }
}
