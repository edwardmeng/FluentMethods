using System.Linq;

namespace FluentMethods.UnitTests
{
    public partial class QueryableFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void WhereIf()
        {
            string name = null;
            var query = new[] {"Fizz", "Buzz"}.AsQueryable();
            var array = query.WhereIf(x => x == "Fizz", !string.IsNullOrEmpty(name)).ToArray();
            Assert.Equal(2, array.Length);
            name = "Buzz";
            array = query.WhereIf(x => x == "Fizz", !string.IsNullOrEmpty(name)).ToArray();
            Assert.Equal(1, array.Length);
        }
    }
}
