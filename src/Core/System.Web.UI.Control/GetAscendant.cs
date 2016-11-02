using System;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Returns the first matching ascendant control.
    /// </summary>
    /// <typeparam name="T">The type of the requested ascendant control.</typeparam>
    /// <param name="control">The control to start the search on.</param>
    /// <param name="predicate">A function to test each ascendant control for a condition.</param>
    /// <returns>The found control</returns>
    public static T GetAscendant<T>(this Control control, Func<T,bool> predicate) where T : class
    {
        var parent = control.Parent;
        while (parent != null)
        {
            if (parent is T)
            {
                var ascendant = parent as T;
                if (predicate(ascendant))
                {
                    return ascendant;
                }
            }
            parent = parent.Parent;
        }
        return null;
    }

    /// <summary>
    /// Returns the first matching ascendant control.
    /// </summary>
    /// <typeparam name="T">The type of the requested ascendant control.</typeparam>
    /// <param name="control">The control to start the search on.</param>
    /// <returns>The found control</returns>
    public static T GetAscendant<T>(this Control control) where T : class
    {
        return control.GetAscendant<T>(ascendant => true);
    }
}