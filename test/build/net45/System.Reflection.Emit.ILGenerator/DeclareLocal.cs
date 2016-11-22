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
        public void DeclareLocal()
        {
            var method = new DynamicMethod("x", typeof(TimeSpan), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<TimeSpan>();
            il.Emit(OpCodes.Ldloca, local);
            il.Emit(OpCodes.Initobj, typeof(TimeSpan));
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<TimeSpan>)method.CreateDelegate(typeof(Func<TimeSpan>));
            Assert.Equal(TimeSpan.Zero, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DeclarePinnedLocal()
        {
            var method = new DynamicMethod("x", typeof(TimeSpan), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<TimeSpan>(true);
            il.Emit(OpCodes.Ldloca, local);
            il.Emit(OpCodes.Initobj, typeof(TimeSpan));
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<TimeSpan>)method.CreateDelegate(typeof(Func<TimeSpan>));
            Assert.Equal(TimeSpan.Zero, func());
        }
    }
}
