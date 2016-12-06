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
        public void IsInstanceOf()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(object) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.IsInstanceOf<int>();
            il.Emit(OpCodes.Ldnull);
            il.Emit(OpCodes.Cgt_Un);
            il.Emit(OpCodes.Ret);

            var func = (Func<object, bool>)method.CreateDelegate(typeof(Func<object, bool>));
            Assert.True(func(20));
            Assert.False(func(Guid.Empty));
        }
    }
}
