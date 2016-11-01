using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static partial class Extensions
{
    private static PropertyInfo GetNameProperty(Type type)
    {
#if NetCore
        var properties = type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public);
#else
        var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
#endif
        return properties.FirstOrDefault(p => p.Name == "Name" && p.PropertyType == typeof(string)) ?? properties.FirstOrDefault(p => p.Name.EndsWith("Name") && p.PropertyType == typeof(string));
    }

    private static Delegate CreateNameFactory(Type type)
    {
        var property = GetNameProperty(type);
        if (property == null) return null;
        var parameter = Expression.Parameter(type, "x");
        return Expression.Lambda(Expression.Property(parameter, property), parameter).Compile();
    }

#if Net35
    private static readonly System.Collections.Generic.Dictionary<Type, Delegate> _namePropertiesCache = new System.Collections.Generic.Dictionary<Type, Delegate>();
    private static readonly object _lockObj = new object();

    private static Func<T, string> GetNameFactory<T>()
    {
        lock (_lockObj)
        {
            return (Func<T, string>)_namePropertiesCache.GetOrAdd(typeof(T), CreateNameFactory);
        }
    }
#else
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, Delegate> _namePropertiesCache = new System.Collections.Concurrent.ConcurrentDictionary<Type, Delegate>();

    private static Func<T, string> GetNameFactory<T>()
        where T : ICustomAttributeProvider
    {
        return (Func<T, string>)_namePropertiesCache.GetOrAdd(typeof(T), CreateNameFactory);
    }
#endif

    /// <summary>
    /// Retrieves the display name of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValue">The default display name for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The display name of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDisplayName<T>(this T provider, string defaultValue = null)
        where T : ICustomAttributeProvider
    {
        return provider.GetDisplayName(() => defaultValue);
    }

    /// <summary>
    /// Retrieves the display name of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default display name for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The display name of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDisplayName<T>(this T provider, Func<string> defaultValueFactory)
        where T : ICustomAttributeProvider
    {
        return provider.GetDisplayName(x => defaultValueFactory());
    }

    /// <summary>
    /// Retrieves the display name of the specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="defaultValueFactory">The function used to generate the default display name for the <see cref="ICustomAttributeProvider"/>.</param>
    /// <returns>The display name of the specified <see cref="ICustomAttributeProvider"/>.</returns>
    public static string GetDisplayName<T>(this T provider, Func<T, string> defaultValueFactory)
        where T : ICustomAttributeProvider
    {
        if (provider == null)
        {
            throw new ArgumentNullException(nameof(provider));
        }
        var displayNameAttribute = provider.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttribute != null)
        {
            return displayNameAttribute.DisplayName;
        }
#if !Net35
        var displayAttribute = provider.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
        if (displayAttribute != null)
        {
            return displayAttribute.GetName();
        }
#endif
        var defaultValue = defaultValueFactory(provider);
        return string.IsNullOrEmpty(defaultValue) ? GetNameFactory<T>()?.Invoke(provider) : defaultValue;
    }
}