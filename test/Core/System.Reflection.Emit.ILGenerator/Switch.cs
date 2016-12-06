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
        public void Switch()
        {
            var method = new DynamicMethod("x", typeof(string), new[] { typeof(int) });
            var il = method.GetILGenerator();
            var defaultCase = il.DefineLabel();
            var endOfMethod = il.DefineLabel();
            // We are initializing our jump table. Note that the labels
            // will be placed later using the MarkLabel method. 

            Label[] jumpTable =
            {
                il.DefineLabel(),
                il.DefineLabel(),
                il.DefineLabel(),
                il.DefineLabel(),
                il.DefineLabel()
            };

            il.Emit(OpCodes.Ldarg_0);
            il.Switch(jumpTable);

            // Branch on default case
            il.Emit(OpCodes.Br_S, defaultCase);

            // Case arg0 = 0
            il.MarkLabel(jumpTable[0]);
            il.Emit(OpCodes.Ldstr, "zero");
            il.Emit(OpCodes.Br_S, endOfMethod);

            // Case arg0 = 1
            il.MarkLabel(jumpTable[1]);
            il.Emit(OpCodes.Ldstr, "one");
            il.Emit(OpCodes.Br_S, endOfMethod);

            // Case arg0 = 2
            il.MarkLabel(jumpTable[2]);
            il.Emit(OpCodes.Ldstr, "two");
            il.Emit(OpCodes.Br_S, endOfMethod);

            // Case arg0 = 3
            il.MarkLabel(jumpTable[3]);
            il.Emit(OpCodes.Ldstr, "three");
            il.Emit(OpCodes.Br_S, endOfMethod);

            // Case arg0 = 4
            il.MarkLabel(jumpTable[4]);
            il.Emit(OpCodes.Ldstr, "four");
            il.Emit(OpCodes.Br_S, endOfMethod);

            // Default case
            il.MarkLabel(defaultCase);
            il.Emit(OpCodes.Ldstr, "many");

            il.MarkLabel(endOfMethod);
            il.Emit(OpCodes.Ret);

            var func = (Func<int, string>)method.CreateDelegate(typeof(Func<int, string>));
            Assert.Equal("zero", func(0));
            Assert.Equal("one", func(1));
            Assert.Equal("two", func(2));
            Assert.Equal("three", func(3));
            Assert.Equal("four", func(4));
            Assert.Equal("many", func(5));
        }
    }
}
