using System;
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
        public void StoreReflectionStaticField()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            il.StoreField(typeof(Product).GetField("State", BindingFlags.Static | BindingFlags.Public), "Initialized");
            il.Emit(OpCodes.Ret);

            var func = (Action)method.CreateDelegate(typeof(Action));
            func();
            Assert.Equal("Initialized", Product.State);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreReflectionInstanceField()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.StoreField(typeof(Product).GetField("Category"), "Fizz");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product>)method.CreateDelegate(typeof(Action<Product>));
            var product = new Product();
            func(product);
            Assert.Equal("Fizz", product.Category);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreInstanceFieldByName()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.StoreField<Product>("Category", "Fizz");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product>)method.CreateDelegate(typeof(Action<Product>));
            var product = new Product();
            func(product);
            Assert.Equal("Fizz", product.Category);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreStaticFieldByName()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            il.StoreField<Product>("State", "Initialized");
            il.Emit(OpCodes.Ret);

            var func = (Action)method.CreateDelegate(typeof(Action));
            func();
            Assert.Equal("Initialized", Product.State);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreInstanceFieldByExpression()
        {
            var method = new DynamicMethod("x", null, new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.StoreField((Product x) => x.Category, "Fizz");
            il.Emit(OpCodes.Ret);

            var func = (Action<Product>)method.CreateDelegate(typeof(Action<Product>));
            var product = new Product();
            func(product);
            Assert.Equal("Fizz", product.Category);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void StoreStaticeFieldByExpression()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            il.StoreField(() => Product.State, "Initialized");
            il.Emit(OpCodes.Ret);

            var func = (Action)method.CreateDelegate(typeof(Action));
            func();
            Assert.Equal("Initialized", Product.State);
        }
    }
}
