using System;
using System.Linq;
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
        public void TypeOfNonGeneric()
        {
            var type = typeof(string);
            var method = new DynamicMethod("x", typeof(Type), new Type[0]);
            var il = method.GetILGenerator();
            il.TypeOf(type);
            il.Emit(OpCodes.Ret);
            var func = (Func<Type>)method.CreateDelegate(typeof(Func<Type>));
            Assert.Equal(type, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TypeOfGeneric()
        {
            var type = typeof(Nullable<>);
            var method = new DynamicMethod("x", typeof(Type), new Type[0]);
            var il = method.GetILGenerator();
            il.TypeOf(type);
            il.Emit(OpCodes.Ret);

            var func = (Func<Type>)method.CreateDelegate(typeof(Func<Type>));
            Assert.Equal(type, func());
        }
    }
}
