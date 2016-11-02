using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FluentMethods.UnitTests
{
    public class SerializationFixture
    {
#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void SerializeBinary()
        {
            // Type
            var @this = new Dictionary<string, string> { { "Fizz", "Buzz" } };

            // Examples
            var result = @this.SerializeBinary(); // Serialize the object into a string.

            // Unit Test
            using (var stream = new MemoryStream(result))
            {
                var binaryRead = new BinaryFormatter();
                var dict = (Dictionary<string, string>)binaryRead.Deserialize(stream);
                Assert.True(dict.ContainsKey("Fizz"));
            }
        }
    }
}
