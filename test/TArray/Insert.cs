namespace FluentMethods.UnitTests
{
    public partial class TArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Insert()
        {
            var array = new[] { "Fizz" };
            array = array.Insert(0, "Buzz");
            Assert.Equal(2, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }
    }
}
