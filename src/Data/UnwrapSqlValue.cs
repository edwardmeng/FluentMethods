using System;
using System.Data.SqlTypes;
using System.IO;
using System.Xml;

public static partial class Extensions
{
    private static object UnwrapSqlValue(object value)
    {
        if (value is SqlString) return ((SqlString)value).Value;
        if (value is SqlBinary) return ((SqlBinary)value).Value;
        if (value is SqlBoolean) return ((SqlBoolean)value).Value;
        if (value is SqlByte) return ((SqlByte)value).Value;
        var sqlBytes = value as SqlBytes;
        if (sqlBytes != null) return sqlBytes.Value;
        var sqlChars = value as SqlChars;
        if (sqlChars != null) return sqlChars.ToSqlString().Value;
        if (value is SqlDateTime) return ((SqlDateTime)value).Value;
        if (value is SqlDecimal) return ((SqlDecimal)value).Value;
        if (value is SqlDouble) return ((SqlDouble)value).Value;
        if (value is SqlGuid) return ((SqlGuid)value).Value;
        if (value is SqlInt16) return ((SqlInt16)value).Value;
        if (value is SqlInt32) return ((SqlInt32)value).Value;
        if (value is SqlInt64) return ((SqlInt64)value).Value;
        if (value is SqlMoney) return ((SqlMoney)value).Value;
        if (value is SqlSingle) return ((SqlSingle)value).Value;
        var sqlXml = value as SqlXml;
        if (sqlXml != null) return sqlXml.Value;
        var xmlReader = value as XmlReader;
        if (xmlReader != null) return new SqlXml(xmlReader).Value;
        var textReader = value as TextReader;
        if (textReader != null) return textReader.ReadToEnd();
        var charArray = value as char[];
        if (charArray != null) return new string(charArray);
        return value;
    }

    private static T UnwrapSqlValue<T>(object value)
    {
        value = UnwrapSqlValue(value);
        if (value is T) return (T)value;
        var stream = value as Stream;
        if (stream == null) return (T) Convert.ChangeType(value, typeof(T));
        if (typeof(T) == typeof(byte[]))
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
#if Net35
                int length;
                byte[] buffer = new byte[0x14000];
                while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memoryStream.Write(buffer, 0, length);
                }
#else
                stream.CopyTo(memoryStream);
#endif
                return (T)(object)memoryStream.ToArray();
            }
        }
        if (typeof(T) == typeof(string))
        {
            using (var reader = new StreamReader(stream))
            {
                return (T)(object)reader.ReadToEnd();
            }
        }
        return (T)Convert.ChangeType(value, typeof(T));
    }
}