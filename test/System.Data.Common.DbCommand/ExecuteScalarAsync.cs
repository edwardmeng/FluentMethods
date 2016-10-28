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
        public async Task ExecuteScalarAsync()
        {
            using (var connection = CreateConnection())
            {
                await connection.EnsureOpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS INTEGER_TABLE(VALUE INTEGER NOT NULL)";
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "DELETE FROM INTEGER_TABLE";
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "INSERT INTO INTEGER_TABLE VALUES(20)";
                    await command.ExecuteNonQueryAsync();

                    command.CommandText = "SELECT VALUE FROM INTEGER_TABLE";
                    Assert.Equal(20, await command.ExecuteScalarAsync<int>());
                }
            }
        }
    }
}
