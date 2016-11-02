using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace FluentMethods.UnitTests
{
    public class MethodInfoFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void IsAsync()
        {
            var methodOpenAsync= typeof(DbConnection).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x => x.Name == "OpenAsync" && x.GetParameters().Length == 0);
            Assert.True(methodOpenAsync.IsAsync());
            var methodOpen = typeof(DbConnection).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x => x.Name == "Open" && x.GetParameters().Length == 0);
            Assert.False(methodOpen.IsAsync());

            var methodExecuteScalarAsync = typeof(DbCommand).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(x => x.Name == "ExecuteScalarAsync" && x.GetParameters().Length == 0);
            Assert.True(methodExecuteScalarAsync.IsAsync());
        }
    }
}
