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
        public void LoadNull()
        {
            var method = new DynamicMethod("xm", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadNull();
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Null(func());
        }
    }
}
