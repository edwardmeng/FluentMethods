using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Finds all the children with specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The specified child control type.</typeparam>
    /// <param name="container">The container.</param>
    /// <returns></returns>
    public static IEnumerable<T> FindChildren<T>(this Control container)
    {
        if (container == null) throw new ArgumentNullException(nameof(container));
        return container.Controls.Cast<Control>().SelectMany(FindChildrenRecursive<T>);
    }

    private static IEnumerable<T> FindChildrenRecursive<T>(Control container)
    {
        if (container is T) yield return (T)(object)container;
        foreach (Control control in container.Controls)
            foreach (T child in FindChildrenRecursive<T>(control))
                yield return child;
    }
}