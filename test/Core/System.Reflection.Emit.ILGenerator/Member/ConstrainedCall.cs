using System;
using System.Globalization;
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
        public void ConstrainedCallReflection()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(IConvertible), typeof(IFormatProvider) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarga, 0);
            il.Emit(OpCodes.Ldarg_1);
            il.ConstrainedCall(typeof(IConvertible), typeof(IConvertible).GetMethod("ToString"));
            il.Emit(OpCodes.Ret);

            var func = (Func<IConvertible, IFormatProvider, string>)method.CreateDelegate(typeof(Func<IConvertible, IFormatProvider, string>));
            Assert.Equal(20.5.ToString(CultureInfo.CurrentCulture), func(20.5, CultureInfo.CurrentCulture));
            Assert.Equal("Fizz", func("Fizz", CultureInfo.CurrentCulture));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConstrainedCallExpression()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(IConvertible), typeof(IFormatProvider) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarga, 0);
            il.Emit(OpCodes.Ldarg_1);
            il.ConstrainedCall(typeof(IConvertible), (IConvertible x, IFormatProvider provider) => x.ToString(provider));
            il.Emit(OpCodes.Ret);

            var func = (Func<IConvertible, IFormatProvider, string>)method.CreateDelegate(typeof(Func<IConvertible, IFormatProvider, string>));
            Assert.Equal(20.5.ToString(CultureInfo.CurrentCulture), func(20.5, CultureInfo.CurrentCulture));
            Assert.Equal("Fizz", func("Fizz", CultureInfo.CurrentCulture));
        }
    }
}
