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
        public async Task ExecuteScalarOrDefaultAsync()
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

                    command.CommandText = "SELECT VALUE FROM INTEGER_TABLE";
                    Assert.Equal(0, await command.ExecuteScalarOrDefaultAsync<int>());
                    Assert.Equal(20, await command.ExecuteScalarOrDefaultAsync(20));
                }
            }
        }
    }
}
