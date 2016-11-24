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
        public void CallReflectionStatic()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Call(typeof(bool).GetMethod("Parse"));
            il.Emit(OpCodes.Ret);

            var func = (Func<string, bool>)method.CreateDelegate(typeof(Func<string, bool>));
            Assert.True(func("true"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallReflectionInstance()
        {
            var method = new DynamicMethod("x", typeof(byte[]), new[] { typeof(Guid) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarga, 0);
            il.Call(typeof(Guid).GetMethod("ToByteArray"));
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid, byte[]>)method.CreateDelegate(typeof(Func<Guid, byte[]>));
            var guid = Guid.NewGuid();
            Assert.Equal(guid.ToByteArray(), func(guid));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallExpressionStatic()
        {
            var method = new DynamicMethod("x", typeof(bool), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Call((string x) => bool.Parse(x));
            il.Emit(OpCodes.Ret);

            var func = (Func<string, bool>)method.CreateDelegate(typeof(Func<string, bool>));
            Assert.True(func("true"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CallExpressionInstance()
        {
            var method = new DynamicMethod("x", typeof(byte[]), new[] { typeof(Guid) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarga, 0);
            il.Call((Guid x) => x.ToByteArray());
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid, byte[]>)method.CreateDelegate(typeof(Func<Guid, byte[]>));
            var guid = Guid.NewGuid();
            Assert.Equal(guid.ToByteArray(), func(guid));
        }
    }
}
