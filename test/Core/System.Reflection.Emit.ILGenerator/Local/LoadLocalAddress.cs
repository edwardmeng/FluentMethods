using System;
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
        public void LoadLocalAddress()
        {
            var method = new DynamicMethod("x", typeof(byte[]), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal(typeof(Guid));
            il.Emit(OpCodes.Call, typeof(Guid).GetMethod("NewGuid"));
            il.Emit(OpCodes.Stloc, local);
            il.LoadLocalAddress(local);
            il.Emit(OpCodes.Call, typeof(Guid).GetMethod("ToByteArray"));
            il.Emit(OpCodes.Ret);

            var func = (Func<byte[]>)method.CreateDelegate(typeof(Func<byte[]>));
            Assert.NotNull(func());
        }
    }
}
