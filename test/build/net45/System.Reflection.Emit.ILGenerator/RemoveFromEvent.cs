﻿using System;
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
            var method = new DynamicMethod("x", null, new[] { typeof(Product), typeof(EventHandler<string>) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.RemoveFromEvent<Product>("TitleChanged");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product, EventHandler<string>>)method.CreateDelegate(typeof(Action<Product, EventHandler<string>>));
            string value = null;
            var product = new Product();
            var handler = new EventHandler<string>((obj, x) => value = x);
            product.TitleChanged += handler;
            func(product, handler);
            product.Title = "Fizz";
            Assert.Null(value);
        }
    }
}
