using System;
using System.Collections;
using System.ComponentModel;

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
                property.SetValue(component, entry.Value.ConvertTo(property.PropertyType, new TypeDescriptorContext(property, component)));
            }
        }
    }
}