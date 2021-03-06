﻿using System;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified <see cref="ICustomAttributeProvider"/>.
    /// </summary>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="attributeType">The type of the attribute to search for.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="provider"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined(this ICustomAttributeProvider provider, Type attributeType)
    {
        return provider.IsDefined(attributeType, true);
    }

    /// <summary>
    /// Indicates whether custom attributes of a specified type are applied to a specified <see cref="ICustomAttributeProvider"/>, and, optionally, applied to its ancestors.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to search for.</typeparam>
    /// <param name="provider">The <see cref="ICustomAttributeProvider"/> to inspect.</param>
    /// <param name="inherit"><c>true</c> to inspect the ancestors of <paramref name="provider"/>; otherwise, <c>false</c>.</param>
    /// <returns><c>true</c> if an attribute of the specified type is applied to <paramref name="provider"/>; otherwise, <c>false</c>.</returns>
    public static bool IsDefined<T>(this ICustomAttributeProvider provider, bool inherit = true)
    {
        return provider.IsDefined(typeof(T), inherit);
    }
}