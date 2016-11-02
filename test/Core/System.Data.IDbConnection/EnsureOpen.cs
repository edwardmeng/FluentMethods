using System.Data;

namespace FluentMethods.UnitTests
{
    public partial class DataFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void EnsureOpen()
        {
            using (var connection = CreateConnection())
            {
                Assert.Equal(ConnectionState.Closed, connection.State);
                connection.EnsureOpen();
                Assert.Equal(ConnectionState.Open, connection.State);
            }
        }
    }
}
