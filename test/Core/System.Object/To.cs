using System;
using System.Globalization;

namespace FluentMethods.UnitTests
{
    public class ConvertFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromEnumConvert()
        {
            Assert.Equal((sbyte)2, DateTimeKind.Local.To<sbyte>());
            Assert.Equal((byte)2, DateTimeKind.Local.To<byte>());
            Assert.Equal((char)2, DateTimeKind.Local.To<char>());
            Assert.Equal(2, DateTimeKind.Local.To<int>());
            Assert.Equal((uint)2, DateTimeKind.Local.To<uint>());
            Assert.Equal((long)2, DateTimeKind.Local.To<long>());
            Assert.Equal((ulong)2, DateTimeKind.Local.To<ulong>());
            Assert.Equal((short)2, DateTimeKind.Local.To<short>());
            Assert.Equal((ushort)2, DateTimeKind.Local.To<ushort>());
            Assert.Equal((float)2, DateTimeKind.Local.To<float>());
            Assert.Equal((double)2, DateTimeKind.Local.To<double>());
            Assert.Equal("Local", DateTimeKind.Local.To<string>());

            Assert.Equal((sbyte?)2, DateTimeKind.Local.To<sbyte?>());
            Assert.Equal((byte?)2, DateTimeKind.Local.To<byte?>());
            Assert.Equal((char?)2, DateTimeKind.Local.To<char?>());
            Assert.Equal((int?)2, DateTimeKind.Local.To<int?>());
            Assert.Equal((uint?)2, DateTimeKind.Local.To<uint?>());
            Assert.Equal((long?)2, DateTimeKind.Local.To<long?>());
            Assert.Equal((ulong?)2, DateTimeKind.Local.To<ulong?>());
            Assert.Equal((short?)2, DateTimeKind.Local.To<short?>());
            Assert.Equal((ushort?)2, DateTimeKind.Local.To<ushort?>());
            Assert.Equal((float?)2, DateTimeKind.Local.To<float?>());
            Assert.Equal((double?)2, DateTimeKind.Local.To<double?>());

            Assert.Equal(null, ((DateTimeKind?)null).To<sbyte?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<byte?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<char?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<uint?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<int?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<long?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<ulong?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<short?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<ushort?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<float?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<double?>());
            Assert.Equal(null, ((DateTimeKind?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToEnumConvert()
        {
            Assert.Equal(DateTimeKind.Local, ((object)(sbyte)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(byte)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(uint)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(long)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(ulong)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(short)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(ushort)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(float)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(double)2).To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(decimal)2).To<DateTimeKind>());

            Assert.Equal(DateTimeKind.Local, "Local".To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "local".To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "2".To<DateTimeKind>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ByteConvert()
        {
            var source = (byte)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((byte?)null).To<sbyte?>());
            Assert.Equal(null, ((byte?)null).To<byte?>());
            Assert.Equal(null, ((byte?)null).To<char?>());
            Assert.Equal(null, ((byte?)null).To<uint?>());
            Assert.Equal(null, ((byte?)null).To<int?>());
            Assert.Equal(null, ((byte?)null).To<long?>());
            Assert.Equal(null, ((byte?)null).To<ulong?>());
            Assert.Equal(null, ((byte?)null).To<short?>());
            Assert.Equal(null, ((byte?)null).To<ushort?>());
            Assert.Equal(null, ((byte?)null).To<decimal?>());
            Assert.Equal(null, ((byte?)null).To<float?>());
            Assert.Equal(null, ((byte?)null).To<double?>());
            Assert.Equal(null, ((byte?)null).To<bool?>());
            Assert.Equal(null, ((byte?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SByteConvert()
        {
            var source = (sbyte)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((sbyte?)null).To<sbyte?>());
            Assert.Equal(null, ((sbyte?)null).To<byte?>());
            Assert.Equal(null, ((sbyte?)null).To<char?>());
            Assert.Equal(null, ((sbyte?)null).To<uint?>());
            Assert.Equal(null, ((sbyte?)null).To<int?>());
            Assert.Equal(null, ((sbyte?)null).To<long?>());
            Assert.Equal(null, ((sbyte?)null).To<ulong?>());
            Assert.Equal(null, ((sbyte?)null).To<short?>());
            Assert.Equal(null, ((sbyte?)null).To<ushort?>());
            Assert.Equal(null, ((sbyte?)null).To<decimal?>());
            Assert.Equal(null, ((sbyte?)null).To<float?>());
            Assert.Equal(null, ((sbyte?)null).To<double?>());
            Assert.Equal(null, ((sbyte?)null).To<bool?>());
            Assert.Equal(null, ((sbyte?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CharConvert()
        {
            var source = (char)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal(source.ToString(), source.To<string>());

            Assert.Equal(null, ((sbyte?)null).To<sbyte?>());
            Assert.Equal(null, ((sbyte?)null).To<byte?>());
            Assert.Equal(null, ((sbyte?)null).To<char?>());
            Assert.Equal(null, ((sbyte?)null).To<uint?>());
            Assert.Equal(null, ((sbyte?)null).To<int?>());
            Assert.Equal(null, ((sbyte?)null).To<long?>());
            Assert.Equal(null, ((sbyte?)null).To<ulong?>());
            Assert.Equal(null, ((sbyte?)null).To<short?>());
            Assert.Equal(null, ((sbyte?)null).To<ushort?>());
            Assert.Equal(null, ((sbyte?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int32Convert()
        {
            var source = 20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((int?)null).To<sbyte?>());
            Assert.Equal(null, ((int?)null).To<byte?>());
            Assert.Equal(null, ((int?)null).To<char?>());
            Assert.Equal(null, ((int?)null).To<uint?>());
            Assert.Equal(null, ((int?)null).To<int?>());
            Assert.Equal(null, ((int?)null).To<long?>());
            Assert.Equal(null, ((int?)null).To<ulong?>());
            Assert.Equal(null, ((int?)null).To<short?>());
            Assert.Equal(null, ((int?)null).To<ushort?>());
            Assert.Equal(null, ((int?)null).To<decimal?>());
            Assert.Equal(null, ((int?)null).To<float?>());
            Assert.Equal(null, ((int?)null).To<double?>());
            Assert.Equal(null, ((int?)null).To<bool?>());
            Assert.Equal(null, ((int?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt32Convert()
        {
            var source = (uint)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((uint?)null).To<sbyte?>());
            Assert.Equal(null, ((uint?)null).To<byte?>());
            Assert.Equal(null, ((uint?)null).To<char?>());
            Assert.Equal(null, ((uint?)null).To<uint?>());
            Assert.Equal(null, ((uint?)null).To<int?>());
            Assert.Equal(null, ((uint?)null).To<long?>());
            Assert.Equal(null, ((uint?)null).To<ulong?>());
            Assert.Equal(null, ((uint?)null).To<short?>());
            Assert.Equal(null, ((uint?)null).To<ushort?>());
            Assert.Equal(null, ((uint?)null).To<decimal?>());
            Assert.Equal(null, ((uint?)null).To<float?>());
            Assert.Equal(null, ((uint?)null).To<double?>());
            Assert.Equal(null, ((uint?)null).To<bool?>());
            Assert.Equal(null, ((uint?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int16Convert()
        {
            var source = (short)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((short?)null).To<sbyte?>());
            Assert.Equal(null, ((short?)null).To<byte?>());
            Assert.Equal(null, ((short?)null).To<char?>());
            Assert.Equal(null, ((short?)null).To<uint?>());
            Assert.Equal(null, ((short?)null).To<int?>());
            Assert.Equal(null, ((short?)null).To<long?>());
            Assert.Equal(null, ((short?)null).To<ulong?>());
            Assert.Equal(null, ((short?)null).To<short?>());
            Assert.Equal(null, ((short?)null).To<ushort?>());
            Assert.Equal(null, ((short?)null).To<decimal?>());
            Assert.Equal(null, ((short?)null).To<float?>());
            Assert.Equal(null, ((short?)null).To<double?>());
            Assert.Equal(null, ((short?)null).To<bool?>());
            Assert.Equal(null, ((short?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt16Convert()
        {
            var source = (ushort)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((ushort?)null).To<sbyte?>());
            Assert.Equal(null, ((ushort?)null).To<byte?>());
            Assert.Equal(null, ((ushort?)null).To<char?>());
            Assert.Equal(null, ((ushort?)null).To<uint?>());
            Assert.Equal(null, ((ushort?)null).To<int?>());
            Assert.Equal(null, ((ushort?)null).To<long?>());
            Assert.Equal(null, ((ushort?)null).To<ulong?>());
            Assert.Equal(null, ((ushort?)null).To<short?>());
            Assert.Equal(null, ((ushort?)null).To<ushort?>());
            Assert.Equal(null, ((ushort?)null).To<decimal?>());
            Assert.Equal(null, ((ushort?)null).To<float?>());
            Assert.Equal(null, ((ushort?)null).To<double?>());
            Assert.Equal(null, ((ushort?)null).To<bool?>());
            Assert.Equal(null, ((ushort?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int64Convert()
        {
            var source = (long)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((long?)null).To<sbyte?>());
            Assert.Equal(null, ((long?)null).To<byte?>());
            Assert.Equal(null, ((long?)null).To<char?>());
            Assert.Equal(null, ((long?)null).To<uint?>());
            Assert.Equal(null, ((long?)null).To<int?>());
            Assert.Equal(null, ((long?)null).To<long?>());
            Assert.Equal(null, ((long?)null).To<ulong?>());
            Assert.Equal(null, ((long?)null).To<short?>());
            Assert.Equal(null, ((long?)null).To<ushort?>());
            Assert.Equal(null, ((long?)null).To<decimal?>());
            Assert.Equal(null, ((long?)null).To<float?>());
            Assert.Equal(null, ((long?)null).To<double?>());
            Assert.Equal(null, ((long?)null).To<bool?>());
            Assert.Equal(null, ((long?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt64Convert()
        {
            var source = (ulong)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((ulong?)null).To<sbyte?>());
            Assert.Equal(null, ((ulong?)null).To<byte?>());
            Assert.Equal(null, ((ulong?)null).To<char?>());
            Assert.Equal(null, ((ulong?)null).To<uint?>());
            Assert.Equal(null, ((ulong?)null).To<int?>());
            Assert.Equal(null, ((ulong?)null).To<long?>());
            Assert.Equal(null, ((ulong?)null).To<ulong?>());
            Assert.Equal(null, ((ulong?)null).To<short?>());
            Assert.Equal(null, ((ulong?)null).To<ushort?>());
            Assert.Equal(null, ((ulong?)null).To<decimal?>());
            Assert.Equal(null, ((ulong?)null).To<float?>());
            Assert.Equal(null, ((ulong?)null).To<double?>());
            Assert.Equal(null, ((ulong?)null).To<bool?>());
            Assert.Equal(null, ((ulong?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DecimalConvert()
        {
            var source = (decimal)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal((char)20, source.To<char>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((decimal?)null).To<sbyte?>());
            Assert.Equal(null, ((decimal?)null).To<byte?>());
            Assert.Equal(null, ((decimal?)null).To<char?>());
            Assert.Equal(null, ((decimal?)null).To<uint?>());
            Assert.Equal(null, ((decimal?)null).To<int?>());
            Assert.Equal(null, ((decimal?)null).To<long?>());
            Assert.Equal(null, ((decimal?)null).To<ulong?>());
            Assert.Equal(null, ((decimal?)null).To<short?>());
            Assert.Equal(null, ((decimal?)null).To<ushort?>());
            Assert.Equal(null, ((decimal?)null).To<decimal?>());
            Assert.Equal(null, ((decimal?)null).To<float?>());
            Assert.Equal(null, ((decimal?)null).To<double?>());
            Assert.Equal(null, ((decimal?)null).To<bool?>());
            Assert.Equal(null, ((decimal?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DoubleConvert()
        {
            var source = (double)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((double?)null).To<sbyte?>());
            Assert.Equal(null, ((double?)null).To<byte?>());
            Assert.Equal(null, ((double?)null).To<char?>());
            Assert.Equal(null, ((double?)null).To<uint?>());
            Assert.Equal(null, ((double?)null).To<int?>());
            Assert.Equal(null, ((double?)null).To<long?>());
            Assert.Equal(null, ((double?)null).To<ulong?>());
            Assert.Equal(null, ((double?)null).To<short?>());
            Assert.Equal(null, ((double?)null).To<ushort?>());
            Assert.Equal(null, ((double?)null).To<decimal?>());
            Assert.Equal(null, ((double?)null).To<float?>());
            Assert.Equal(null, ((double?)null).To<double?>());
            Assert.Equal(null, ((double?)null).To<bool?>());
            Assert.Equal(null, ((double?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SingleConvert()
        {
            var source = (float)20;
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, source.To<bool>());
            Assert.Equal("20", source.To<string>());

            Assert.Equal(null, ((float?)null).To<sbyte?>());
            Assert.Equal(null, ((float?)null).To<byte?>());
            Assert.Equal(null, ((float?)null).To<char?>());
            Assert.Equal(null, ((float?)null).To<uint?>());
            Assert.Equal(null, ((float?)null).To<int?>());
            Assert.Equal(null, ((float?)null).To<long?>());
            Assert.Equal(null, ((float?)null).To<ulong?>());
            Assert.Equal(null, ((float?)null).To<short?>());
            Assert.Equal(null, ((float?)null).To<ushort?>());
            Assert.Equal(null, ((float?)null).To<decimal?>());
            Assert.Equal(null, ((float?)null).To<float?>());
            Assert.Equal(null, ((float?)null).To<double?>());
            Assert.Equal(null, ((float?)null).To<bool?>());
            Assert.Equal(null, ((float?)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromStringConvert()
        {
            var source = "20";
            Assert.Equal((sbyte)20, source.To<sbyte>());
            Assert.Equal((byte)20, source.To<byte>());
            Assert.Equal(20, source.To<int>());
            Assert.Equal((uint)20, source.To<uint>());
            Assert.Equal((long)20, source.To<long>());
            Assert.Equal((ulong)20, source.To<ulong>());
            Assert.Equal((short)20, source.To<short>());
            Assert.Equal((ushort)20, source.To<ushort>());
            Assert.Equal((decimal)20, source.To<decimal>());
            Assert.Equal((float)20, source.To<float>());
            Assert.Equal((double)20, source.To<double>());
            Assert.Equal(true, "true".To<bool>());
            Assert.Equal(false, "false".To<bool>());
            Assert.Equal("20", source.To<string>());
            Assert.Equal(DateTimeKind.Local, "Local".To<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "2".To<DateTimeKind>());

            Assert.Equal(null, ((string)null).To<sbyte?>());
            Assert.Equal(null, ((string)null).To<byte?>());
            Assert.Equal(null, ((string)null).To<char?>());
            Assert.Equal(null, ((string)null).To<uint?>());
            Assert.Equal(null, ((string)null).To<int?>());
            Assert.Equal(null, ((string)null).To<long?>());
            Assert.Equal(null, ((string)null).To<ulong?>());
            Assert.Equal(null, ((string)null).To<short?>());
            Assert.Equal(null, ((string)null).To<ushort?>());
            Assert.Equal(null, ((string)null).To<decimal?>());
            Assert.Equal(null, ((string)null).To<float?>());
            Assert.Equal(null, ((string)null).To<double?>());
            Assert.Equal(null, ((string)null).To<bool?>());
            Assert.Equal(null, ((string)null).To<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertOperator()
        {
            Assert.Equal(20, new IntPtr(20).To<int>());
            Assert.Equal(new IntPtr(20), 20.To<IntPtr>());
            DateTime now = DateTime.Now;
            Assert.Equal(new DateTimeOffset(now), now.To<DateTimeOffset>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertByTypeConverter()
        {
            var url = "http://www.google.com";
            Assert.Equal(new Uri(url), url.To<Uri>());
            Assert.Equal(url, new Uri(url).To<string>());

            var guid = Guid.NewGuid();
            Assert.Equal(guid, guid.ToString().To<Guid>());

            var dateTime = new DateTime(2016, 9, 24, 14, 40, 30);
            Assert.Equal(dateTime, dateTime.ToString(CultureInfo.CurrentCulture).To<DateTime>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertArray()
        {
            Guid guid1 = Guid.NewGuid(), guid2 = Guid.NewGuid();
            var array = new[] { guid1.ToString(), guid2.ToString() }.To<Guid[]>();
            Assert.Equal(guid1, array[0]);
            Assert.Equal(guid2, array[1]);
        }
    }
}
