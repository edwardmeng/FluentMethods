using System.Data;
using System.Threading.Tasks;

namespace FluentMethods.UnitTests
{
    public partial class DataFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public async Task EnsureOpenAsync()
        {
            using (var connection = CreateConnection())
            {
                Assert.Equal(ConnectionState.Closed, connection.State);
                await connection.EnsureOpenAsync();
                Assert.Equal(ConnectionState.Open, connection.State);
            }
        }
    }
}
