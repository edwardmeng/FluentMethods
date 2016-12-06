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
        public void LoadString()
        {
            LoadString(null);
            LoadString(string.Empty);
            LoadString("Fizz");
        }

        private void LoadString(string value)
        {
            var method = new DynamicMethod("xm", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadString(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Equal(value, func());
        }
    }
}
