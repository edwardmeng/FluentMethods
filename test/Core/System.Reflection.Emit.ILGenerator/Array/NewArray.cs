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
        public void NewArray()
        {
            var method = new DynamicMethod("x", typeof(int[]), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(5);
            il.NewArray<int>();
            il.Emit(OpCodes.Ret);

            var func = (Func<int[]>)method.CreateDelegate(typeof(Func<int[]>));
            var array = func();
            Assert.NotNull(array);
            Assert.Equal(5, array.Length);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NewArrayWithLength()
        {
            var method = new DynamicMethod("x", typeof(int[]), new Type[0]);
            var il = method.GetILGenerator();
            il.NewArray<int>(5);
            il.Emit(OpCodes.Ret);

            var func = (Func<int[]>)method.CreateDelegate(typeof(Func<int[]>));
            var array = func();
            Assert.NotNull(array);
            Assert.Equal(5, array.Length);
        }
    }
}
