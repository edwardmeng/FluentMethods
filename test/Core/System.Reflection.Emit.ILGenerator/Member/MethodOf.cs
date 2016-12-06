using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MethodOfNonGeneric()
        {
            var info = typeof(string).GetMethod("GetHashCode");
            var method = new DynamicMethod("x", typeof(MethodBase), new Type[0]);
            var il = method.GetILGenerator();
            il.MethodOf(info);
            il.Emit(OpCodes.Ret);

            var func = (Func<MethodBase>)method.CreateDelegate(typeof(Func<MethodBase>));
            Assert.Equal(info, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void MethodOfGeneric()
        {
            var info = typeof(Queryable).GetMethod("All");
            var method = new DynamicMethod("x", typeof(MethodBase), new Type[0]);
            var il = method.GetILGenerator();
            il.MethodOf(info);
            il.Emit(OpCodes.Ret);

            var func = (Func<MethodBase>)method.CreateDelegate(typeof(Func<MethodBase>));
            Assert.Equal(info, func());
        }
    }
}
