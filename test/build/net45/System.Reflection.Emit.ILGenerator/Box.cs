using System;
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
        public void BoxStruct()
        {
            var method = new DynamicMethod("x",typeof(object),new[] {typeof(int)});
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.BoxFrom<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int, object>) method.CreateDelegate(typeof(Func<int, object>));
            Assert.Equal(20, func(20));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BoxClass()
        {
            var method = new DynamicMethod("x", typeof(object), new[] { typeof(Version) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.BoxFrom<Version>();
            il.Emit(OpCodes.Ret);

            var func = (Func<Version, object>)method.CreateDelegate(typeof(Func<Version, object>));
            Assert.Equal(new Version("1.2"), func(new Version("1.2")));
        }
    }
}
