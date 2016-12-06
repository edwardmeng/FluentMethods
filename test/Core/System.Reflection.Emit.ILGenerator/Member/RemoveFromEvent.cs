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
        public void RemoveFromEvent()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(Product), typeof(TitleChangeHandler) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.RemoveFromEvent<Product>("TitleChanged");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product, TitleChangeHandler>)method.CreateDelegate(typeof(Action<Product, TitleChangeHandler>));
            string value = null;
            var product = new Product();
            var handler = new TitleChangeHandler((obj, x) => value = x);
            product.TitleChanged += handler;
            func(product, handler);
            product.Title = "Fizz";
            Assert.Null(value);
        }
    }
}
