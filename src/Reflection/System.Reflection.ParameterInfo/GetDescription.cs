using System;
using System.ComponentModel;
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
        var descriptionAttribute = member.GetCustomAttribute<DescriptionAttribute>();
        if (descriptionAttribute != null)
        {
            return descriptionAttribute.Description;
        }
#if !Net35
        var displayAttribute = member.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetDescription();
        }
#endif
        return defaultValueFactory();
    }
}