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
        public void LoadReflectionStaticField()
        {
            var method = new DynamicMethod("x", typeof(Guid), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadField(typeof(Guid).GetField("Empty", BindingFlags.Static | BindingFlags.Public));
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid>)method.CreateDelegate(typeof(Func<Guid>));
            Assert.Equal(Guid.Empty, func());
        }

#if NetCore
                [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadReflectionInstanceField()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.LoadField(typeof(Product).GetField("Category"));
            il.Emit(OpCodes.Ret);

            var func = (Func<Product, string>)method.CreateDelegate(typeof(Func<Product, string>));
            Assert.Equal("Fizz", func(new Product { Category = "Fizz" }));
        }

#if NetCore
                [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadInstanceFieldByName()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.LoadField<Product>("Category");
            il.Emit(OpCodes.Ret);

            var func = (Func<Product, string>)method.CreateDelegate(typeof(Func<Product, string>));
            Assert.Equal("Fizz", func(new Product { Category = "Fizz" }));
        }

#if NetCore
                [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadStaticFieldByName()
        {
            var method = new DynamicMethod("x", typeof(Guid), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadField<Guid>("Empty");
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid>)method.CreateDelegate(typeof(Func<Guid>));
            Assert.Equal(Guid.Empty, func());
        }

#if NetCore
                [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadInstanceFieldByExpression()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(Product) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.LoadField((Product x) => x.Category);
            il.Emit(OpCodes.Ret);

            var func = (Func<Product, string>)method.CreateDelegate(typeof(Func<Product, string>));
            Assert.Equal("Fizz", func(new Product { Category = "Fizz" }));
        }

#if NetCore
                [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadStaticeFieldByExpression()
        {
            var method = new DynamicMethod("x", typeof(Guid), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadField(() => Guid.Empty);
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid>)method.CreateDelegate(typeof(Func<Guid>));
            Assert.Equal(Guid.Empty, func());
        }
    }
}
