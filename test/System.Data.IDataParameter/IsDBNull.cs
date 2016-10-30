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
        public void DataParameterIsDBNull()
        {
            using (var connection = CreateConnection())
            {
                connection.EnsureOpen();
                using (var command = connection.CreateCommand())
                {
                    var parameter = command.CreateParameter();
                    Assert.True(parameter.IsDBNull());

                    parameter.Value = DBNull.Value;
                    Assert.True(parameter.IsDBNull());
                }
            }
        }
    }
}
