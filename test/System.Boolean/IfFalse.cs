namespace FluentMethods.UnitTests
{
    public partial class BooleanFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IfFalse()
        {
            string value1 = "";
            string value2 = "";
            const bool conditionTrue = true;
            const bool conditionFalse = false;
            conditionTrue.IfFalse(() => value1 = "FizzBuzz"); // value1 = "";
            conditionFalse.IfFalse(() => value2 = "FizzBuzz"); // value2 = "FizzBuzz";
            Assert.Equal("", value1);
            Assert.Equal("FizzBuzz", value2);
        }
    }
}
