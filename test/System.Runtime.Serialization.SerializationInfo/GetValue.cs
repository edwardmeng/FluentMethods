using System;
using System.Runtime.Serialization;

namespace FluentMethods.UnitTests
{
    public class SerializationInfoFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetBooleanValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value",true);

            Assert.True(info.GetValue<bool>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetCharValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", 'A');

            Assert.Equal('A',info.GetValue<char>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetDateTimeValue()
        {
            var value = DateTime.Now;
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", value);

            Assert.Equal(value, info.GetValue<DateTime>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetDecimalValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (decimal)20.5);

            Assert.Equal((decimal)20.5, info.GetValue<decimal>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetDoubleValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", 20.5);

            Assert.Equal(20.5, info.GetValue<double>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetFloatValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (float)20.5);

            Assert.Equal((float)20.5, info.GetValue<float>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetInt16Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (short)20);

            Assert.Equal((short)20, info.GetValue<short>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetUInt16Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (ushort)20);

            Assert.Equal((ushort)20, info.GetValue<ushort>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetInt32Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", 20);

            Assert.Equal(20, info.GetValue<int>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetUInt32Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (uint)20);

            Assert.Equal((uint)20, info.GetValue<uint>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetInt64Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (long)20);

            Assert.Equal((long)20, info.GetValue<long>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetUInt64Value()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (ulong)20);

            Assert.Equal((ulong)20, info.GetValue<ulong>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetByteValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (byte)20);

            Assert.Equal((byte)20, info.GetValue<byte>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetSByteValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", (sbyte)20);

            Assert.Equal((sbyte)20, info.GetValue<sbyte>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetStringValue()
        {
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", "Fizz");

            Assert.Equal("Fizz", info.GetValue<string>("Value"));
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void GetGuidValue()
        {
            var value = Guid.NewGuid();
            var info = new SerializationInfo(typeof(object), new FormatterConverter());
            info.AddValue("Value", value.ToString());

            Assert.Equal(value, info.GetValue<Guid>("Value"));
        }
    }
}
