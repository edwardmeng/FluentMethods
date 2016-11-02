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
        public void RemoveOneDimension()
        {
            Array array = new[] { "Fizz", "Buzz" };
            array = array.Remove("Fizz");
            Assert.Equal(1, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void RemoveMultipleDimension()
        {
            Array array = new[,] { { "Fizz1", "Fizz2" }, { "Buzz1", "Buzz2" } };
            Assert.Throws<RankException>(() => array = array.Remove("Buzz1"));
        }
    }
}
