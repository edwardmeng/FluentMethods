using System;
using System.Collections.Generic;
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
        public void GetReflectionStaticProperty()
        {
            var method = new DynamicMethod("x", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.GetProperty(typeof(Environment).GetProperty("NewLine", BindingFlags.Static | BindingFlags.Public));
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Equal(Environment.NewLine, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetReflectionInstanceProperty()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(Version) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.GetProperty(typeof(Version).GetProperty("Major"));
            il.Emit(OpCodes.Ret);

            var func = (Func<Version, int>)method.CreateDelegate(typeof(Func<Version, int>));
            Assert.Equal(5, func(new Version("5.0.3")));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetInstancePropertyByName()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(Version) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.GetProperty<Version>("Major");
            il.Emit(OpCodes.Ret);

            var func = (Func<Version, int>)method.CreateDelegate(typeof(Func<Version, int>));
            Assert.Equal(5, func(new Version("5.0.3")));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetStaticPropertyByName()
        {
            var method = new DynamicMethod("x", typeof(Comparer<int>), new Type[0]);
            var il = method.GetILGenerator();
            il.GetProperty<Comparer<int>>("Default");
            il.Emit(OpCodes.Ret);

            var func = (Func<Comparer<int>>)method.CreateDelegate(typeof(Func<Comparer<int>>));
            Assert.Equal(Comparer<int>.Default, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetInstancePropertyByExpression()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(Version) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.GetProperty((Version version) => version.Major);
            il.Emit(OpCodes.Ret);

            var func = (Func<Version, int>)method.CreateDelegate(typeof(Func<Version, int>));
            Assert.Equal(5, func(new Version("5.0.3")));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetStaticePropertyByExpression()
        {
            var method = new DynamicMethod("x", typeof(string), new Type[0]);
            var il = method.GetILGenerator();
            il.GetProperty(() => Environment.NewLine);
            il.Emit(OpCodes.Ret);

            var func = (Func<string>)method.CreateDelegate(typeof(Func<string>));
            Assert.Equal(Environment.NewLine, func());
        }
    }
}
