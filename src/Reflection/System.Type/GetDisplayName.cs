using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static partial class Extensions
{
    public static string GetDisplayName(this Type type, string defaultValue = null)
    {
        return type.GetDisplayName(() => defaultValue);
    }

    public static string GetDisplayName(this Type type, Func<string> defaultValueFactory)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        var displayNameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttribute != null)
        {
            return displayNameAttribute.DisplayName;
        }
        var displayAttribute = type.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetName();
        }
        var defaultValue = defaultValueFactory();
        return string.IsNullOrEmpty(defaultValue) ? type.Name : defaultValue;
    }
}