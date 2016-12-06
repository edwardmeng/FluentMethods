using System;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void InitializeBlock()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(IntPtr) }, typeof(ILGeneratorFixture));
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.InitializeBlock(25, 20);
            il.Emit(OpCodes.Ret);

            var func = (Action<IntPtr>)method.CreateDelegate(typeof(Action<IntPtr>));
            var buffer = new byte[25];
            var gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            func(gcHandle.AddrOfPinnedObject());
            Assert.Equal((byte)25, buffer[19]);
            Assert.Equal((byte)0, buffer[20]);
        }
    }
}
