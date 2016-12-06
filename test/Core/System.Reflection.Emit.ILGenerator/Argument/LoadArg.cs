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
        public void LoadArg()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.LoadArg(0);
            il.Emit(OpCodes.Call, typeof(string).GetMethod("ToUpper", Type.EmptyTypes));
            il.Emit(OpCodes.Ret);

            var func = (Func<string, string>)method.CreateDelegate(typeof(Func<string, string>));
            Assert.Equal("FIZZ", func("Fizz"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadArgMuchArguments()
        {
            var method = new DynamicMethod("x", typeof(string), new[]
            {
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(string)
            });
            var il = method.GetILGenerator();
            il.LoadArg(256);
            il.Emit(OpCodes.Call, typeof(string).GetMethod("ToUpper", Type.EmptyTypes));
            il.Emit(OpCodes.Ret);

            var func = (MuchArgumentsHandler<string, string>)method.CreateDelegate(typeof(MuchArgumentsHandler<string, string>));
            Assert.Equal("FIZZ", func(
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                "Fizz"));
        }
    }
}
