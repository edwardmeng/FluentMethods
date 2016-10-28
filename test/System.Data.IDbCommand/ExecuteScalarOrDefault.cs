namespace FluentMethods.UnitTests
{
    public partial class DataFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ExecuteScalarOrDefault()
        {
            using (var connection = CreateConnection())
            {
                connection.EnsureOpen();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS INTEGER_TABLE(VALUE INTEGER NOT NULL)";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM INTEGER_TABLE";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT VALUE FROM INTEGER_TABLE";
                    Assert.Equal(0, command.ExecuteScalarOrDefault<int>());
                    Assert.Equal(20, command.ExecuteScalarOrDefault(20));
                }
            }
        }
    }
}
