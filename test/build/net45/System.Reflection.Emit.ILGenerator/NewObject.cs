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
        public void NewObject()
        {
            var method = new DynamicMethod("x", typeof(Version), new Type[0]);
            var il = method.GetILGenerator();
            il.NewObject<Version>();
            il.Emit(OpCodes.Ret);

            var func = (Func<Version>)method.CreateDelegate(typeof(Func<Version>));
            Assert.Equal(new Version(), func());
        }
    }
}
