using System;
using System.ComponentModel;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves the description of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValue">The default description for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The description of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDescription<T>(this T provider, string defaultValue = null)
        where T : ICustomAttributeProvider
    {
        return provider.GetDescription(x => defaultValue);
    }

    /// <summary>
    /// Retrieves the description of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default description for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The description of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDescription<T>(this T provider, Func<string> defaultValueFactory)
        where T : ICustomAttributeProvider
    {
        return provider.GetDescription(x => defaultValueFactory());
    }

    /// <summary>
    /// Retrieves the description of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default description for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The description of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDescription<T>(this T provider, Func<T, string> defaultValueFactory)
        where T: ICustomAttributeProvider
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }
        var descriptionAttribute = provider.GetCustomAttribute<DescriptionAttribute>();
        if (descriptionAttribute != null)
        {
            return descriptionAttribute.Description;
        }
#if !Net35
        var displayAttribute = provider.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetDescription();
        }
#endif
        return defaultValueFactory(provider);
    }
}