using System;

namespace FluentMethods.UnitTests
{
    public partial class DataFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DataRecordIsDBNull()
        {
            using (var connection = CreateConnection())
            {
                connection.EnsureOpen();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS INTEGER_TABLE(VALUE INTEGER)";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM INTEGER_TABLE";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO INTEGER_TABLE VALUES(20)";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT VALUE FROM INTEGER_TABLE";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Assert.Throws<ArgumentException>(() => reader.IsDBNull("Fizz"));
                            Assert.False(reader.IsDBNull("VALUE"));
                        }
                    }

                    command.CommandText = "DELETE FROM INTEGER_TABLE";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO INTEGER_TABLE VALUES(NULL)";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT VALUE FROM INTEGER_TABLE";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Assert.True(reader.IsDBNull("VALUE"));
                        }
                    }
                }
            }
        }
    }
}
