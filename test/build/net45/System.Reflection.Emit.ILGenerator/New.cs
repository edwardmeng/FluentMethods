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
