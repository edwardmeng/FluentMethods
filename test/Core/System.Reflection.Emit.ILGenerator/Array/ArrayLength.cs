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
        public void ArrayLength()
        {
            var method = new DynamicMethod("x", typeof(int), new[] { typeof(int[]) });
            var il = method.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.ArrayLength();
            il.Emit(OpCodes.Ret);

            var func = (Func<int[], int>)method.CreateDelegate(typeof(Func<int[], int>));
            Assert.Equal(3, func(new[] { 1, 2, 3 }));
        }
    }
}
