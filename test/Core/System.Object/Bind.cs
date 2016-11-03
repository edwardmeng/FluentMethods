using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public partial class ObjectFixture
    {
        public class Product
        {
            public string Title { get; set; }

            public string Description { get; set; }

            public int Price { get; set; }

            public string Warehouse { get; set; }
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BindDictionaryValues()
        {
            var component = new Product
            {
                Title = "Fizz"
            };
            component.Bind(new Dictionary<string, object>
            {
                {"Description","Buzz" },
                {"Price",20 }
            });
            Assert.Equal("Buzz", component.Description);
            Assert.Equal(component.Price, 20);
        }

#if NetCore
        [Xunit.Fact]
#else
        [NUnit.Framework.Test]
#endif
        public void BindAnonymousValues()
        {
            var component = new Product
            {
                Title = "Fizz"
            };
            component.Bind(new
            {
                Description="Buzz",
                Price =20
            });
            Assert.Equal("Buzz", component.Description);
            Assert.Equal(component.Price, 20);
        }
    }
}
