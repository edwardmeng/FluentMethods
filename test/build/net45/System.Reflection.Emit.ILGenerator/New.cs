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
        public void NewClassInstanceByConstructor()
        {
            var method = new DynamicMethod("x", typeof(Version), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.New(typeof(Version).GetConstructor(new[] { typeof(string) }));
            il.Emit(OpCodes.Ret);

            var func = (Func<string, Version>)method.CreateDelegate(typeof(Func<string, Version>));
            Assert.Equal(new Version("1.0.2"), func("1.0.2"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NewValueByConstructor()
        {
            var method = new DynamicMethod("x", typeof(decimal), new[] { typeof(int) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.New(typeof(decimal).GetConstructor(new[] { typeof(int) }));
            il.Emit(OpCodes.Ret);

            var func = (Func<int, decimal>)method.CreateDelegate(typeof(Func<int, decimal>));
            Assert.Equal(new decimal(25), func(25));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NewClassInstance()
        {
            var method = new DynamicMethod("x", typeof(Version), new Type[0]);
            var il = method.GetILGenerator();
            il.New<Version>();
            il.Emit(OpCodes.Ret);

            var func = (Func<Version>)method.CreateDelegate(typeof(Func<Version>));
            Assert.Equal(new Version(), func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NewValueInstance()
        {
            var method = new DynamicMethod("x", typeof(TimeSpan), new Type[0]);
            var il = method.GetILGenerator();
            il.New<TimeSpan>();
            il.Emit(OpCodes.Ret);

            var func = (Func<TimeSpan>)method.CreateDelegate(typeof(Func<TimeSpan>));
            Assert.Equal(TimeSpan.Zero, func());
        }
    }
}
