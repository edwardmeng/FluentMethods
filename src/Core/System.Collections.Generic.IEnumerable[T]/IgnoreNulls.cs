using System.Collections.Generic;
using System.Diagnostics;

public static partial class Extensions
{
    /// <summary>
    /// Returns enumerable object based on target, which does not contains null references.
    /// If target is null reference, returns empty enumerable object.
    /// </summary>
    /// <typeparam name="T">Type of items in target.</typeparam>
    /// <param name="source">Target enumerable object. Can be null.</param>
    /// <remarks>Contributed by tencokacistromy, http://www.codeplex.com/site/users/view/tencokacistromy </remarks>
    [DebuggerStepThrough]
    public static IEnumerable<T> IgnoreNulls<T>(this IEnumerable<T> source)
    {
        if (ReferenceEquals(source, null))
        {
            yield break;
        }

        foreach (var item in source)
        {
            if (ReferenceEquals(item, null)) continue;
            yield return item;
        }
    }
}