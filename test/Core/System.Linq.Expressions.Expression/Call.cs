using System;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace FluentMethods.UnitTests
{
    public partial class ExpressionFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallInstanceNonGenericNoArguments()
        {
            var variable = Expression.Parameter(typeof(Guid), "x");
            var guid = Guid.NewGuid();
            Assert.Equal(guid.ToByteArray(), variable.Call("ToByteArray").ToLambda<Func<Guid, byte[]>>(variable).Compile()(guid));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallInstanceNonGeneric()
        {
            var variable = Expression.Parameter(typeof(DateTime), "x");
            var dateTime = DateTime.Now;
            Assert.Equal(dateTime.AddDays(1), variable.Call("AddDays", Expression.Constant((double)1)).ToLambda<Func<DateTime, DateTime>>(variable).Compile()(dateTime));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallInstanceGenericNoArguments()
        {
            var product = new ObjectFixture.Product() {Price = 20};
            var parameter = Expression.Parameter(typeof(ObjectFixture.Product), "x");
            Assert.Equal((decimal) 20, parameter.Call("GetPrice", typeof(decimal)).ToLambda<Func<ObjectFixture.Product, decimal>>(parameter).Compile()(product));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallInstanceGeneric()
        {
            var parameter = Expression.Parameter(typeof(DbDataReader), "reader");
            var table = new DataTable();
            table.Columns.Add("Value", typeof(int));
            var row = table.NewRow();
            row[0] = 20;
            table.Rows.Add(row);
            var reader = new DataTableReader(table);
            reader.Read();
            Assert.Equal(20, parameter.Call("GetFieldValue", new[] { typeof(int) }, Expression.Constant(0)).ToLambda<Func<DbDataReader, int>>(parameter).Compile()(reader));
        }
    }
}
