using System;

namespace FluentMethods.UnitTests
{
    public partial class ArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AddOneDimension()
        {
            Array array = new[] { "Fizz" };
            array = array.Add("Buzz");
            Assert.Equal(2, array.Length);
            Assert.Equal("Buzz", array.GetValue(1));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void AddMultipleDimension()
        {
            Array array = new[,] { { "Fizz1", "Fizz2" }, { "Buzz1", "Buzz2" } };
            Assert.Throws<RankException>(() => array = array.Add("Buzz"));
        }
    }
}
