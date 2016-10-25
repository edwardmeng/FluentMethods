using System;
using System.Linq;

namespace FluentMethods.UnitTests
{
    public partial class ArrayFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Traverse()
        {
            Array array = new[,] { { "A", "B" }, { "C", "D" } };
            string result = null;
            int sum = 0;
            array.Traverse(x => result += x.ToString());
            Assert.Equal("ABCD", result);
            array.Traverse((x, i) => sum += i.Sum());
            Assert.Equal(4, sum);
        }
    }
}
