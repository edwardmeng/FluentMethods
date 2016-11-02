namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsInstanceOf()
        {
            var stringObject = (object)"FizzBuzz";
            bool result1 = stringObject.IsInstanceOf(typeof(string));
            bool result2 = stringObject.IsInstanceOf<string>();
            bool result3 = stringObject.IsInstanceOf<object>();
            bool result4 = stringObject.IsInstanceOf<int>();
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }
    }
}
