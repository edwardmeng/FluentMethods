namespace FluentMethods.UnitTests
{
    public partial class TArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AddDimension()
        {
            var array = new[] { "Fizz" };
            array = array.Add("Buzz");
            Assert.Equal(2, array.Length);
            Assert.Equal("Buzz", array.GetValue(1));
        }
    }
}
