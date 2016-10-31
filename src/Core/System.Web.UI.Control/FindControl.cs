using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Performs a typed search of a control within the current naming container.
    /// </summary>
    /// <typeparam name="T">The control type</typeparam>
    /// <param name="control">The parent control / naming container to search within.</param>
    /// <param name="id">The id of the control to be found.</param>
    /// <returns>The found control</returns>
    public static T FindControl<T>(this Control control, string id) where T : class
    {
        return control.FindControl(id) as T;
    }
}