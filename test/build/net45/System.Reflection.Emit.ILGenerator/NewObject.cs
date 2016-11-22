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
        public void NewObjectByConstructor()
        {
            var method = new DynamicMethod("x", typeof(Version), new[] { typeof(string) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.NewObject(typeof(Version).GetConstructor(new[] { typeof(string) }));
            il.Emit(OpCodes.Ret);

            var func = (Func<string, Version>)method.CreateDelegate(typeof(Func<string, Version>));
            Assert.Equal(new Version("1.0.2"), func("1.0.2"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void NewObjectByType()
        {
            var method = new DynamicMethod("x", typeof(Version), new Type[0]);
            var il = method.GetILGenerator();
            il.NewObject<Version>();
            il.Emit(OpCodes.Ret);

            var func = (Func<Version>)method.CreateDelegate(typeof(Func<Version>));
            Assert.Equal(new Version(), func());
        }
    }
}
