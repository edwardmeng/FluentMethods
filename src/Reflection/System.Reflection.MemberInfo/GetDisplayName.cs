using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves the display name of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValue">The default display name for the member.</param>
    /// <returns>The display name of the specified member.</returns>
    public static string GetDisplayName(this MemberInfo member, string defaultValue = null)
    {
        return member.GetDisplayName(() => defaultValue);
    }

    /// <summary>
    /// Retrieves the display name of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default display name for the member.</param>
    /// <returns>The display name of the specified member.</returns>
    public static string GetDisplayName(this MemberInfo member, Func<string> defaultValueFactory)
    {
        return member.GetDisplayName(x => defaultValueFactory());
    }

    /// <summary>
    /// Retrieves the display name of the specified member.
    /// </summary>
    /// <param name="member">The member to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default display name for the member.</param>
    /// <returns>The display name of the specified member.</returns>
    public static string GetDisplayName(this MemberInfo member, Func<MemberInfo, string> defaultValueFactory)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }
        var displayNameAttribute = member.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttribute != null)
        {
            return displayNameAttribute.DisplayName;
        }
        var displayAttribute = member.GetCustomAttribute<DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetName();
        }
        var defaultValue = defaultValueFactory(member);
        return string.IsNullOrEmpty(defaultValue) ? member.Name : defaultValue;
    }
}