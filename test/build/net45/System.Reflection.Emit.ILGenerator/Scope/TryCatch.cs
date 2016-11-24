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

            var func = (Func<bool>) method.CreateDelegate(typeof(Func<bool>));
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

            Assert.Throws<OverflowException>((Action) method.CreateDelegate(typeof(Action)));
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
                using (il.Catch<NotFiniteNumberException>())
                {
                    il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<Exception>) method.CreateDelegate(typeof(Func<Exception>));
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

            var func = (Func<Exception>) method.CreateDelegate(typeof(Func<Exception>));
            Assert.IsInstanceOf<OverflowException>(func());
        }


#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryAnonymousCatchFilterSuccess()
        {
            // todo: If the current ILGenerator is associated with a DynamicMethod object, 
            // emitting filtered exception blocks is not supported. DynamicILInfo can be used to construct a dynamic method that uses filtered exception blocks.
            var method = new DynamicMethod("x", typeof(Exception), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                il.LoadNull().StoreLocal(local);
                using (il.Catch(() =>
                {
                    //il.LoadConst(true);
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

            var func = (Func<Exception>)method.CreateDelegate(typeof(Func<Exception>));
            Assert.IsInstanceOf<ArgumentNullException>(func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void TryCatchFilterSuccessExplicitlyType()
        {
            // todo: If the current ILGenerator is associated with a DynamicMethod object, 
            // emitting filtered exception blocks is not supported. DynamicILInfo can be used to construct a dynamic method that uses filtered exception blocks.
            var method = new DynamicMethod("x", typeof(Exception), new Type[0]);
            var il = method.GetILGenerator();
            var local = il.DeclareLocal<Exception>();
            using (il.Try())
            {
                il.Throw<ArgumentNullException>("value");
                il.LoadNull().StoreLocal(local);
                using (il.Catch<ArgumentNullException>(() =>
                {
                    il.LoadConst(true);
                    //il.GetProperty<ArgumentNullException, string>(ex => ex.ParamName);
                    //il.LoadString("value");
                    //il.Call((string x, string y) => string.Equals(x, y));
                }))
                {
                    //il.ConvertTo<Exception>().StoreLocal(local);
                }
            }
            il.LoadLocal(local);
            il.Emit(OpCodes.Ret);

            var func = (Func<Exception>)method.CreateDelegate(typeof(Func<Exception>));
            Assert.IsInstanceOf<ArgumentNullException>(func());
        }
    }
}
