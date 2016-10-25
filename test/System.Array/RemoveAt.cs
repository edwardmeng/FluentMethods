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
        public void RemoveAtOneDimension()
        {
            Array array = new[] { "Fizz" , "Buzz" };
            array = array.RemoveAt(0);
            Assert.Equal(1, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void RemoveAtMultipleDimension()
        {
            Array array = new[,] { { "Fizz1", "Fizz2" }, { "Buzz1", "Buzz2" } };
            Assert.Throws<RankException>(() => array = array.RemoveAt(0));
        }
    }
}
