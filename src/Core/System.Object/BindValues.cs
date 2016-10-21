using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

public static partial class Extensions
{
    private class TypeDescriptorContext : ITypeDescriptorContext
    {
        public TypeDescriptorContext(PropertyDescriptor propDesc, object instance)
        {
            PropertyDescriptor = propDesc;
            Instance = instance;
        }

        public object GetService(Type serviceType)
        {
            return null;
        }

        public bool OnComponentChanging()
        {
            return true;
        }

        public void OnComponentChanged()
        {
        }

        public IContainer Container => null;

        public object Instance { get; }

        public PropertyDescriptor PropertyDescriptor { get; }
    }

    public static void BindValues(this object component, IDictionary fieldValues)
    {
        var properties = TypeDescriptor.GetProperties(component);
        foreach (DictionaryEntry entry in fieldValues)
        {
            string propertyName = entry.Key.ToString();
            var property = properties.Find(propertyName, false) ?? properties.Find(propertyName, true);
            if (property != null && !property.IsReadOnly)
            {
                var propertyValue = entry.Value;
                var converter = property.Converter;
                if (entry.Value != null &&
#if NetCore
                    !property.PropertyType.GetTypeInfo().IsInstanceOfType(entry.Value)
#else
                    !property.PropertyType.IsInstanceOfType(entry.Value) 
#endif
                    && converter != null && converter.CanConvertFrom(entry.Value.GetType()))
                {
                    propertyValue = converter.ConvertFrom(entry.Value);
                }
                property.SetValue(component, propertyValue.ConvertTo(property.PropertyType, new TypeDescriptorContext(property, component)));
            }
        }
    }
}