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
        public void Return()
        {
            var method = new DynamicMethod("x", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(20);
            il.Return();

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(20, func());
        }
    }
}
