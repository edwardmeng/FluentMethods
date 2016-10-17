using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static partial class Extensions
{
    public static string GetDescription(this ParameterInfo member, string defaultValue = null)
    {
        return member.GetDescription(() => defaultValue);
    }

    public static string GetDescription(this ParameterInfo member, Func<string> defaultValueFactory)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }
        var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetDescription();
        }
        return defaultValueFactory();
    }
}