using System;
using System.ComponentModel;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves the description of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValue">The default description for the member.</param>
    /// <returns>The description of the specified member.</returns>
    public static string GetDescription(this MemberInfo member, string defaultValue = null)
    {
        return member.GetDescription(x => defaultValue);
    }

    /// <summary>
    /// Retrieves the description of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default description for the member.</param>
    /// <returns>The description of the specified member.</returns>
    public static string GetDescription(this MemberInfo member, Func<string> defaultValueFactory)
    {
        return member.GetDescription(x => defaultValueFactory());
    }

    /// <summary>
    /// Retrieves the description of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default description for the member.</param>
    /// <returns>The description of the specified member.</returns>
    public static string GetDescription(this MemberInfo member, Func<MemberInfo, string> defaultValueFactory)
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
        return defaultValueFactory(member);
    }
}