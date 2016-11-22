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
        public void LoadConstInt32()
        {
            LoadConstInt32(-1);
            LoadConstInt32(0);
            LoadConstInt32(1);
            LoadConstInt32(2);
            LoadConstInt32(3);
            LoadConstInt32(4);
            LoadConstInt32(5);
            LoadConstInt32(6);
            LoadConstInt32(7);
            LoadConstInt32(8);
            LoadConstInt32(20);
            LoadConstInt32(200);
            LoadConstInt32(-200);
        }

        private void LoadConstInt32(int value)
        {
            var method = new DynamicMethod("xm", typeof(int), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<int>)method.CreateDelegate(typeof(Func<int>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstUInt32()
        {
            LoadConstUInt32(0);
            LoadConstUInt32(1);
            LoadConstUInt32(2);
            LoadConstUInt32(3);
            LoadConstUInt32(4);
            LoadConstUInt32(5);
            LoadConstUInt32(6);
            LoadConstUInt32(7);
            LoadConstUInt32(8);
            LoadConstUInt32(20);
            LoadConstUInt32(200);
        }

        private void LoadConstUInt32(uint value)
        {
            var method = new DynamicMethod("xm", typeof(uint), new Type[0]);
            var il = method.GetILGenerator();
            il.LoadConst(value);
            il.Emit(OpCodes.Ret);

            var func = (Func<uint>)method.CreateDelegate(typeof(Func<uint>));
            Assert.Equal(value, func());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadConstInt64()
        {
            
        }
    }
}
