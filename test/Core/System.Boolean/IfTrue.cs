using System;

namespace FluentMethods.UnitTests
{
    public partial class BooleanFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IfTrue()
        {
            string value1 = "";
            string value2 = "";
            const bool conditionTrue = true;
            const bool conditionFalse = false;
            conditionTrue.IfTrue(() => value1 = "FizzBuzz"); // value1 = "FizzBuzz";
            conditionFalse.IfTrue(() => value2 = "FizzBuzz"); // value2 = "";
            Assert.Equal("FizzBuzz", value1);
            Assert.Equal("", value2);
        }
    }
}
