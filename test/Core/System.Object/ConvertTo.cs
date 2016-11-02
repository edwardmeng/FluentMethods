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
            Assert.Equal((sbyte)2, DateTimeKind.Local.ConvertTo<sbyte>());
            Assert.Equal((byte)2, DateTimeKind.Local.ConvertTo<byte>());
            Assert.Equal((char)2, DateTimeKind.Local.ConvertTo<char>());
            Assert.Equal(2, DateTimeKind.Local.ConvertTo<int>());
            Assert.Equal((uint)2, DateTimeKind.Local.ConvertTo<uint>());
            Assert.Equal((long)2, DateTimeKind.Local.ConvertTo<long>());
            Assert.Equal((ulong)2, DateTimeKind.Local.ConvertTo<ulong>());
            Assert.Equal((short)2, DateTimeKind.Local.ConvertTo<short>());
            Assert.Equal((ushort)2, DateTimeKind.Local.ConvertTo<ushort>());
            Assert.Equal((float)2, DateTimeKind.Local.ConvertTo<float>());
            Assert.Equal((double)2, DateTimeKind.Local.ConvertTo<double>());
            Assert.Equal("Local", DateTimeKind.Local.ConvertTo<string>());

            Assert.Equal((sbyte?)2, DateTimeKind.Local.ConvertTo<sbyte?>());
            Assert.Equal((byte?)2, DateTimeKind.Local.ConvertTo<byte?>());
            Assert.Equal((char?)2, DateTimeKind.Local.ConvertTo<char?>());
            Assert.Equal((int?)2, DateTimeKind.Local.ConvertTo<int?>());
            Assert.Equal((uint?)2, DateTimeKind.Local.ConvertTo<uint?>());
            Assert.Equal((long?)2, DateTimeKind.Local.ConvertTo<long?>());
            Assert.Equal((ulong?)2, DateTimeKind.Local.ConvertTo<ulong?>());
            Assert.Equal((short?)2, DateTimeKind.Local.ConvertTo<short?>());
            Assert.Equal((ushort?)2, DateTimeKind.Local.ConvertTo<ushort?>());
            Assert.Equal((float?)2, DateTimeKind.Local.ConvertTo<float?>());
            Assert.Equal((double?)2, DateTimeKind.Local.ConvertTo<double?>());

            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<char?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<int?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<long?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<short?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<float?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<double?>());
            Assert.Equal(null, ((DateTimeKind?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ToEnumConvert()
        {
            Assert.Equal(DateTimeKind.Local, ((object)(sbyte)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(byte)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(uint)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(long)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(ulong)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(short)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(ushort)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(float)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(double)2).ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, ((object)(decimal)2).ConvertTo<DateTimeKind>());

            Assert.Equal(DateTimeKind.Local, "Local".ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "local".ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "2".ConvertTo<DateTimeKind>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ByteConvert()
        {
            var source = (byte)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((byte?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<char?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<int?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<long?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<short?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<float?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<double?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((byte?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SByteConvert()
        {
            var source = (sbyte)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((sbyte?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<char?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<int?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<long?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<short?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<float?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<double?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void CharConvert()
        {
            var source = (char)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal(source.ToString(), source.ConvertTo<string>());

            Assert.Equal(null, ((sbyte?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<char?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<int?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<long?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<short?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((sbyte?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int32Convert()
        {
            var source = 20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((int?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((int?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((int?)null).ConvertTo<char?>());
            Assert.Equal(null, ((int?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((int?)null).ConvertTo<int?>());
            Assert.Equal(null, ((int?)null).ConvertTo<long?>());
            Assert.Equal(null, ((int?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((int?)null).ConvertTo<short?>());
            Assert.Equal(null, ((int?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((int?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((int?)null).ConvertTo<float?>());
            Assert.Equal(null, ((int?)null).ConvertTo<double?>());
            Assert.Equal(null, ((int?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((int?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt32Convert()
        {
            var source = (uint)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((uint?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<char?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<int?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<long?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<short?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<float?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<double?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((uint?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int16Convert()
        {
            var source = (short)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((short?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((short?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((short?)null).ConvertTo<char?>());
            Assert.Equal(null, ((short?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((short?)null).ConvertTo<int?>());
            Assert.Equal(null, ((short?)null).ConvertTo<long?>());
            Assert.Equal(null, ((short?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((short?)null).ConvertTo<short?>());
            Assert.Equal(null, ((short?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((short?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((short?)null).ConvertTo<float?>());
            Assert.Equal(null, ((short?)null).ConvertTo<double?>());
            Assert.Equal(null, ((short?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((short?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt16Convert()
        {
            var source = (ushort)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((ushort?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<char?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<int?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<long?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<short?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<float?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<double?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((ushort?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void Int64Convert()
        {
            var source = (long)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((long?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((long?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((long?)null).ConvertTo<char?>());
            Assert.Equal(null, ((long?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((long?)null).ConvertTo<int?>());
            Assert.Equal(null, ((long?)null).ConvertTo<long?>());
            Assert.Equal(null, ((long?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((long?)null).ConvertTo<short?>());
            Assert.Equal(null, ((long?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((long?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((long?)null).ConvertTo<float?>());
            Assert.Equal(null, ((long?)null).ConvertTo<double?>());
            Assert.Equal(null, ((long?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((long?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void UInt64Convert()
        {
            var source = (ulong)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((ulong?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<char?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<int?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<long?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<short?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<float?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<double?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((ulong?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DecimalConvert()
        {
            var source = (decimal)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal((char)20, source.ConvertTo<char>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((decimal?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<char?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<int?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<long?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<short?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<float?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<double?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((decimal?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void DoubleConvert()
        {
            var source = (double)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((double?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((double?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((double?)null).ConvertTo<char?>());
            Assert.Equal(null, ((double?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((double?)null).ConvertTo<int?>());
            Assert.Equal(null, ((double?)null).ConvertTo<long?>());
            Assert.Equal(null, ((double?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((double?)null).ConvertTo<short?>());
            Assert.Equal(null, ((double?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((double?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((double?)null).ConvertTo<float?>());
            Assert.Equal(null, ((double?)null).ConvertTo<double?>());
            Assert.Equal(null, ((double?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((double?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SingleConvert()
        {
            var source = (float)20;
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, source.ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());

            Assert.Equal(null, ((float?)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((float?)null).ConvertTo<byte?>());
            Assert.Equal(null, ((float?)null).ConvertTo<char?>());
            Assert.Equal(null, ((float?)null).ConvertTo<uint?>());
            Assert.Equal(null, ((float?)null).ConvertTo<int?>());
            Assert.Equal(null, ((float?)null).ConvertTo<long?>());
            Assert.Equal(null, ((float?)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((float?)null).ConvertTo<short?>());
            Assert.Equal(null, ((float?)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((float?)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((float?)null).ConvertTo<float?>());
            Assert.Equal(null, ((float?)null).ConvertTo<double?>());
            Assert.Equal(null, ((float?)null).ConvertTo<bool?>());
            Assert.Equal(null, ((float?)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void FromStringConvert()
        {
            var source = "20";
            Assert.Equal((sbyte)20, source.ConvertTo<sbyte>());
            Assert.Equal((byte)20, source.ConvertTo<byte>());
            Assert.Equal(20, source.ConvertTo<int>());
            Assert.Equal((uint)20, source.ConvertTo<uint>());
            Assert.Equal((long)20, source.ConvertTo<long>());
            Assert.Equal((ulong)20, source.ConvertTo<ulong>());
            Assert.Equal((short)20, source.ConvertTo<short>());
            Assert.Equal((ushort)20, source.ConvertTo<ushort>());
            Assert.Equal((decimal)20, source.ConvertTo<decimal>());
            Assert.Equal((float)20, source.ConvertTo<float>());
            Assert.Equal((double)20, source.ConvertTo<double>());
            Assert.Equal(true, "true".ConvertTo<bool>());
            Assert.Equal(false, "false".ConvertTo<bool>());
            Assert.Equal("20", source.ConvertTo<string>());
            Assert.Equal(DateTimeKind.Local, "Local".ConvertTo<DateTimeKind>());
            Assert.Equal(DateTimeKind.Local, "2".ConvertTo<DateTimeKind>());

            Assert.Equal(null, ((string)null).ConvertTo<sbyte?>());
            Assert.Equal(null, ((string)null).ConvertTo<byte?>());
            Assert.Equal(null, ((string)null).ConvertTo<char?>());
            Assert.Equal(null, ((string)null).ConvertTo<uint?>());
            Assert.Equal(null, ((string)null).ConvertTo<int?>());
            Assert.Equal(null, ((string)null).ConvertTo<long?>());
            Assert.Equal(null, ((string)null).ConvertTo<ulong?>());
            Assert.Equal(null, ((string)null).ConvertTo<short?>());
            Assert.Equal(null, ((string)null).ConvertTo<ushort?>());
            Assert.Equal(null, ((string)null).ConvertTo<decimal?>());
            Assert.Equal(null, ((string)null).ConvertTo<float?>());
            Assert.Equal(null, ((string)null).ConvertTo<double?>());
            Assert.Equal(null, ((string)null).ConvertTo<bool?>());
            Assert.Equal(null, ((string)null).ConvertTo<string>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertOperator()
        {
            Assert.Equal(20, new IntPtr(20).ConvertTo<int>());
            Assert.Equal(new IntPtr(20), 20.ConvertTo<IntPtr>());
            DateTime now = DateTime.Now;
            Assert.Equal(new DateTimeOffset(now), now.ConvertTo<DateTimeOffset>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertByTypeConverter()
        {
            var url = "http://www.google.com";
            Assert.Equal(new Uri(url), url.ConvertTo<Uri>());
            Assert.Equal(url, new Uri(url).ConvertTo<string>());

            var guid = Guid.NewGuid();
            Assert.Equal(guid, guid.ToString().ConvertTo<Guid>());

            var dateTime = new DateTime(2016, 9, 24, 14, 40, 30);
            Assert.Equal(dateTime, dateTime.ToString(CultureInfo.CurrentCulture).ConvertTo<DateTime>());
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void ConvertArray()
        {
            Guid guid1 = Guid.NewGuid(), guid2 = Guid.NewGuid();
            var array = new[] { guid1.ToString(), guid2.ToString() }.ConvertTo<Guid[]>();
            Assert.Equal(guid1, array[0]);
            Assert.Equal(guid2, array[1]);
        }
    }
}
