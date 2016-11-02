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
        public void InsertOneDimension()
        {
            Array array = new[] { "Fizz" };
            array = array.Insert(0, "Buzz");
            Assert.Equal(2, array.Length);
            Assert.Equal("Buzz", array.GetValue(0));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void InsertMultipleDimension()
        {
            Array array = new[,] { { "Fizz1", "Fizz2" }, { "Buzz1", "Buzz2" } };
            Assert.Throws<RankException>(() => array = array.Insert(0, "Buzz"));
        }
    }
}
