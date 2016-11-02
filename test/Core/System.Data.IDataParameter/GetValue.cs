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
        public void DataParameterGetValue()
        {
            using (var connection = CreateConnection())
            {
                connection.EnsureOpen();
                using (var command = connection.CreateCommand())
                {
                    var parameter = command.CreateParameter();
                    Assert.Null(parameter.GetValue<string>());

                    parameter.Value = "Fizz";
                    Assert.Equal("Fizz", parameter.GetValue<string>());

                    parameter.Value = DBNull.Value;
                    Assert.Null(parameter.GetValue<string>());
                }
            }
        }
    }
}
