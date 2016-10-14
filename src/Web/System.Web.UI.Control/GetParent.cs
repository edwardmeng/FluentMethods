using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Returns the first matching parent control.
    /// </summary>
    /// <typeparam name="T">The typ of the requested parent control.</typeparam>
    /// <param name="control">The control to start the search on.</param>
    /// <returns>The found control</returns>
    public static T GetParent<T>(this Control control) where T : class
    {
        var parent = control.Parent;
        while (parent != null)
        {
            if (parent is T) return parent as T;
            parent = parent.Parent;
        }
        return null;
    }
}