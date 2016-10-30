namespace FluentMethods.UnitTests
{
    public partial class DataFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DataRecordGetValue()
        {
            using (var connection = CreateConnection())
            {
                connection.EnsureOpen();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS SAMPLE_TABLE(INTVALUE INTEGER, TEXTVALUE TEXT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "DELETE FROM SAMPLE_TABLE";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO SAMPLE_TABLE VALUES(20,'Fizz')";
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT INTVALUE,TEXTVALUE FROM SAMPLE_TABLE";
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Assert.Equal(20, reader.GetValue<int>("INTVALUE"));
                            Assert.Equal(20, reader.GetValue<long>("INTVALUE"));
                            Assert.Equal("Fizz", reader.GetValue<string>("TEXTVALUE"));
                        }
                    }
                }
            }
        }
    }
}
