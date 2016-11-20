using System.Collections.Generic;

namespace FluentMethods.UnitTests
{
    public class Product
    {
        public static string State;

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Warehouse { get; set; }

        public string Category;

        public T GetPrice<T>()
        {
            return Price.To<T>();
        }
    }
    public partial class ObjectFixture
    {

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
