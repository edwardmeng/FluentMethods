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
        public void InitializeValue()
        {
            var method = new DynamicMethod("x", typeof(TimeSpan), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(TimeSpan));
            il.Emit(OpCodes.Ldloca, local);
            il.InitializeValue<TimeSpan>();
            il.Emit(OpCodes.Ldloc, local);
            il.Emit(OpCodes.Ret);

            var func = (Func<TimeSpan>)method.CreateDelegate(typeof(Func<TimeSpan>));
            Assert.Equal(TimeSpan.Zero, func());
        }
    }
}
