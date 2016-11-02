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
        public void Paginate()
        {
            var query = new[] { "Fizz", "Buzz", "Foo" }.AsQueryable();
            var array = query.Paginate(1, 1).ToArray();
            Assert.Equal(1, array.Length);
            Assert.Equal("Buzz", array[0]);
        }
    }
}
