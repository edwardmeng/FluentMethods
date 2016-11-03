using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
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

    /// <summary>
    /// Binds property values to the specified component.
    /// </summary>
    /// <param name="component">The component to bind property values.</param>
    /// <param name="values">The property values to bind to the specified comonent.</param>
    public static void Bind(this object component, IDictionary values)
    {
        if (values == null) return;
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }
        var properties = TypeDescriptor.GetProperties(component);
        foreach (DictionaryEntry entry in values)
        {
            string propertyName = entry.Key.ToString();
            var property = properties.Find(propertyName, false) ?? properties.Find(propertyName, true);
            if (property != null && !property.IsReadOnly)
            {
                var propertyValue = entry.Value;
                if (propertyValue != null &&
#if NetCore
                    !property.PropertyType.GetTypeInfo().IsInstanceOfType(entry.Value)
#else
                    !property.PropertyType.IsInstanceOfType(entry.Value)
#endif
                    )
                {
                    // Only the type converter marked with TypeConverterAttribute can be affected, the converter marked on the property type should not be used.
                    var converter = property.Attributes[typeof(TypeConverterAttribute)] != null ? property.Converter : null;
                    if (converter != null && converter.CanConvertFrom(entry.Value.GetType()))
                    {
                        property.SetValue(component, converter.ConvertFrom(entry.Value));
                        return;
                    }
                }
                property.SetValue(component, propertyValue.To(property.PropertyType, new TypeDescriptorContext(property, component)));
            }
        }
    }

    /// <summary>
    /// Binds property values to the specified component.
    /// </summary>
    /// <param name="component">The component to bind property values.</param>
    /// <param name="values">The property values to bind to the specified comonent. It can be anonymous object.</param>
    public static void Bind(this object component, object values)
    {
        if (values == null) return;
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }
        var dictionary = values as IDictionary;
        if (dictionary != null)
        {
            component.Bind(dictionary);
            return;
        }
        component.Bind(
            TypeDescriptor.GetProperties(values)
                .Cast<PropertyDescriptor>()
                .ToDictionary(property => property.Name, property => property.GetValue(values)));
    }
}