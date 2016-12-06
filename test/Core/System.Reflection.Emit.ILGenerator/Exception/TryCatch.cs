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
        public void TryCatchSuccessExplicitly()
        {
            var method = new DynamicMethod("x", typeof(bool), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<bool>();
            using (il.Try())
            {
                il.Throw<OverflowException>();
                il.StoreLocal(local, false);
                using (il.Catch<OverflowException>())
                {
                    il.StoreLocal(local, true);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<bool>)method.CreateDelegate(typeof(Func<bool>));
            Assert.True(func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryCatchFailExplicitly()
        {
            var method = new DynamicMethod("x", null, new Type[0]);
            var il = method.GetILGenerator();
            using (il.Try())
            {
                il.Throw<OverflowException>();

                using (il.Catch<DivideByZeroException>())
                {
                }
            }
            il.Emit(OpCodes.Ret);

            Assert.Throws<OverflowException>((Action)method.CreateDelegate(typeof(Action)));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryMultipleCatchExplicitly()
        {
            var method = new DynamicMethod("x", typeof(Exception), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<OverflowException>();
                il.LoadNull().StoreLocal(local);
                using (il.Catch<OverflowException>())
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
                using (il.Catch<DivideByZeroException>())
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<Exception>)method.CreateDelegate(typeof(Func<Exception>));
            Assert.IsInstanceOf<OverflowException>(func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryAnonymousCatch()
        {
            var method = new DynamicMethod("x", typeof(Exception), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<OverflowException>();
                il.LoadNull().StoreLocal(local);
                using (il.Catch())
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<Exception>)method.CreateDelegate(typeof(Func<Exception>));
            Assert.IsInstanceOf<OverflowException>(func());
        }


#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryAnonymousCatchFilterSuccess()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryAnonymousCatchFilterSuccess",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(Exception),
                new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                il.LoadNull().StoreLocal(local);
                using (il.Catch(() =>
                {
                    il.ConvertTo<ArgumentNullException>();
                    il.GetProperty<ArgumentNullException, string>(ex => ex.ParamName);
                    il.LoadString("value");
                    il.Call((string x, string y) => string.Equals(x, y));
                }))
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            Assert.IsInstanceOf<ArgumentNullException>(type.GetMethod("x").Invoke(null, new object[0]));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryAnonymousCatchFilterFail()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryAnonymousCatchFilterFail",
                TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(Exception),
                new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            il.LoadNull().StoreLocal(local);
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                using (il.Catch(() =>
                {
                    il.ConvertTo<ArgumentNullException>();
                    il.GetProperty<ArgumentNullException, string>(ex => ex.ParamName);
                    il.LoadString("name");
                    il.Call((string x, string y) => string.Equals(x, y));
                }))
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
                using (il.Catch())
                {
                    il.LoadNull().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            Assert.Null(type.GetMethod("x").Invoke(null, new object[0]));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryCatchFilterSuccessExplicitlyType()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryCatchFilterSuccessExplicitlyType",
               TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(Exception),
                new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                il.LoadNull().StoreLocal(local);
                using (il.Catch<ArgumentNullException>(() =>
                {
                    il.GetProperty<ArgumentNullException, string>(ex => ex.ParamName);
                    il.LoadString("value");
                    il.Call((string x, string y) => string.Equals(x, y));
                }))
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            Assert.IsInstanceOf<ArgumentNullException>(type.GetMethod("x").Invoke(null, new object[0]));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryCatchFilterFailExplicitlyType()
        {
            var typeBuilder = _moduleBuilder.DefineType("TryCatchFilterFailExplicitlyType",
               TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit);
            var method = typeBuilder.DefineMethod("x",
                MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(ArgumentNullException),
                new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<ArgumentNullException>();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                using (il.Catch<ArgumentNullException>(() =>
                {
                    il.GetProperty<ArgumentNullException, string>(ex => ex.ParamName);
                    il.LoadString("name");
                    il.Call((string x, string y) => string.Equals(x, y));
                }))
                {
                    il.StoreLocal(local);
                }
                using (il.Catch())
                {
                    il.LoadNull().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

#if NetCore
            var type = typeBuilder.CreateTypeInfo();
#else
            var type = typeBuilder.CreateType();
#endif
            Assert.Null(type.GetMethod("x").Invoke(null, new object[0]));
        }
    }
}
