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
        public void AddToEvent()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(Product), typeof(TitleChangeHandler) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.AddToEvent<Product>("TitleChanged");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product, TitleChangeHandler>)method.CreateDelegate(typeof(Action<Product, TitleChangeHandler>));
            string value = null;
            var product = new Product();
            func(product, (obj, x) => value = x);
            product.Title = "Fizz";
            Assert.Equal("Fizz", value);
        }
    }
}
