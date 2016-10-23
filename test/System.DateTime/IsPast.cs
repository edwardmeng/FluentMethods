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
        public void IsPast()
        {
            DateTime @this = DateTime.Now.AddDays(1);
            bool value1 = @this.IsPast(); // return false;
            bool value2 = @this.AddYears(-1).IsPast(); // return true;
            Assert.False(value1);
            Assert.True(value2);
        }
    }
}
