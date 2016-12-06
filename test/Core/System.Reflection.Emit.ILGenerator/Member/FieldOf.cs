using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FieldOfNonGeneric()
        {
            var info = typeof(Guid).GetField("Empty", BindingFlags.Static | BindingFlags.Public);
            var method = new DynamicMethod("x", typeof(FieldInfo), new Type[0]);
            var il = method.GetILGenerator();
            il.FieldOf(info);
            il.Emit(OpCodes.Ret);

            var func = (Func<FieldInfo>)method.CreateDelegate(typeof(Func<FieldInfo>));
            Assert.Equal(info, func());
        }
#if !Net35
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FieldOfGeneric()
        {
            var info = typeof(CallSite<>).GetField("Target");
            var method = new DynamicMethod("x", typeof(FieldInfo), new Type[0]);
            var il = method.GetILGenerator();
            il.FieldOf(info);
            il.Emit(OpCodes.Ret);

            var func = (Func<FieldInfo>)method.CreateDelegate(typeof(Func<FieldInfo>));
            Assert.Equal(info, func());
        }
#endif
    }
}
