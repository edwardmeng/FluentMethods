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
    /// <param name="control">The control to start the search on.</param>
    /// <param name="predicate">A function to test each descendent control for a condition.</param>
    /// <returns></returns>
    public static IEnumerable<T> FindDescendents<T>(this Control control, Func<T, bool> predicate) where T : class
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        return control.Controls.Cast<Control>().SelectMany(x => FindDescendentsRecursive(x, predicate));
    }

    /// <summary>
    /// Finds all the children with specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The specified child control type.</typeparam>
    /// <param name="control">The control to start the search on.</param>
    /// <returns></returns>
    public static IEnumerable<T> FindDescendents<T>(this Control control) where T : class
    {
        return control.FindDescendents<T>(descendent => true);
    }

    private static IEnumerable<T> FindDescendentsRecursive<T>(Control container, Func<T, bool> predicate) where T : class
    {
        var descendent = container as T;
        if (descendent != null && predicate(descendent)) yield return (T)(object)container;
        foreach (Control control in container.Controls)
            foreach (var child in FindDescendentsRecursive(control, predicate))
                yield return child;
    }
}