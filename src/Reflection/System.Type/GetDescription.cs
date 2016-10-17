using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static partial class Extensions
{
    public static string GetDescription(this Type type, string defaultValue = null)
    {
        return type.GetDescription(() => defaultValue);
    }

    public static string GetDescription(this Type type, Func<string> defaultValueFactory)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        var descriptionAttribute = type.GetCustomAttribute<DescriptionAttribute>();
        if (descriptionAttribute != null)
        {
            return descriptionAttribute.Description;
        }
        var displayAttribute = type.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetDescription();
        }
        return defaultValueFactory();
    }
}