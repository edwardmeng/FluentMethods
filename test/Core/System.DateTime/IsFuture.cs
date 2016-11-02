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
        public void IsFuture()
        {
            DateTime @this = DateTime.Now.AddDays(1);
            bool value1 = @this.IsFuture(); // return true;
            bool value2 = @this.AddYears(-1).IsFuture(); // return false;
            Assert.True(value1);
            Assert.False(value2);
        }
    }
}
