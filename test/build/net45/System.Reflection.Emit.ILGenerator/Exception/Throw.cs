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
        public void ThrowDefault()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            il.Throw<OverflowException>();
            il.Emit(OpCodes.Ret);

            Assert.Throws<OverflowException>((Action)method.CreateDelegate(typeof(Action)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ThrowWithMessage()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            il.Throw<OverflowException>("Cannot accept values over 100 for add.");
            il.Emit(OpCodes.Ret);

            Assert.Throws<OverflowException>((Action)method.CreateDelegate(typeof(Action)));
        }
    }
}
