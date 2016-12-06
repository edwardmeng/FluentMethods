using System;
using System.Reflection;
using System.Reflection.Emit;

namespace FluentMethods.UnitTests
{
    public partial class ILGeneratorFixture
    {
        private delegate TResult MuchArgumentsHandler<in T, out TResult>(object x0, object x1, object x2, object x3, object x4, object x5, object x6, object x7, object x8, object x9, object x10, object x11, object x12, object x13, object x14, object x15, object x16, object x17, object x18, object x19, object x20, object x21, object x22, object x23, object x24, object x25, object x26, object x27, object x28, object x29, object x30, object x31, object x32, object x33, object x34, object x35, object x36, object x37, object x38, object x39, object x40, object x41, object x42, object x43, object x44, object x45, object x46, object x47, object x48, object x49, object x50, object x51, object x52, object x53, object x54, object x55, object x56, object x57, object x58, object x59, object x60, object x61, object x62, object x63, object x64, object x65, object x66, object x67, object x68, object x69, object x70, object x71, object x72, object x73, object x74, object x75, object x76, object x77, object x78, object x79, object x80, object x81, object x82, object x83, object x84, object x85, object x86, object x87, object x88, object x89, object x90, object x91, object x92, object x93, object x94, object x95, object x96, object x97, object x98, object x99, object x100, object x101, object x102, object x103, object x104, object x105, object x106, object x107, object x108, object x109, object x110, object x111, object x112, object x113, object x114, object x115, object x116, object x117, object x118, object x119, object x120, object x121, object x122, object x123, object x124, object x125, object x126, object x127, object x128, object x129, object x130, object x131, object x132, object x133, object x134, object x135, object x136, object x137, object x138, object x139, object x140, object x141, object x142, object x143, object x144, object x145, object x146, object x147, object x148, object x149, object x150, object x151, object x152, object x153, object x154, object x155, object x156, object x157, object x158, object x159, object x160, object x161, object x162, object x163, object x164, object x165, object x166, object x167, object x168, object x169, object x170, object x171, object x172, object x173, object x174, object x175, object x176, object x177, object x178, object x179, object x180, object x181, object x182, object x183, object x184, object x185, object x186, object x187, object x188, object x189, object x190, object x191, object x192, object x193, object x194, object x195, object x196, object x197, object x198, object x199, object x200, object x201, object x202, object x203, object x204, object x205, object x206, object x207, object x208, object x209, object x210, object x211, object x212, object x213, object x214, object x215, object x216, object x217, object x218, object x219, object x220, object x221, object x222, object x223, object x224, object x225, object x226, object x227, object x228, object x229, object x230, object x231, object x232, object x233, object x234, object x235, object x236, object x237, object x238, object x239, object x240, object x241, object x242, object x243, object x244, object x245, object x246, object x247, object x248, object x249, object x250, object x251, object x252, object x253, object x254, object x255, T value);
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadArgAddress()
        {
            var method = new DynamicMethod("x", typeof(byte[]), new[] { typeof(Guid) });
            var il = method.GetILGenerator();
            il.LoadArgAddress(0);
            il.Emit(OpCodes.Call, typeof(Guid).GetMethod("ToByteArray"));
            il.Emit(OpCodes.Ret);

            var func = (Func<Guid, byte[]>)method.CreateDelegate(typeof(Func<Guid, byte[]>));
            var guid = Guid.NewGuid();
            Assert.Equal(guid.ToByteArray(), func(guid));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void LoadArgAddressMuchArguments()
        {
            var method = new DynamicMethod("x", typeof(byte[]), new[]
            {
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),typeof(object),
                typeof(Guid)
            });
            var il = method.GetILGenerator();
            il.LoadArgAddress(256);
            il.Emit(OpCodes.Call, typeof(Guid).GetMethod("ToByteArray"));
            il.Emit(OpCodes.Ret);

            var func = (MuchArgumentsHandler<Guid, byte[]>)method.CreateDelegate(typeof(MuchArgumentsHandler<Guid,byte[]>));
            var guid = Guid.NewGuid();
            Assert.Equal(guid.ToByteArray(), func(
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                guid));
        }
    }
}
