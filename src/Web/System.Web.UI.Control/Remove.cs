using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Removes the specified control from hierarchy.
    /// </summary>
    /// <param name="control">The control to be removed.</param>
    public static bool Remove(this Control control)
    {
        var parent = control?.Parent;
        if (parent == null || parent.Controls.IsReadOnly) return false;
        parent.Controls.Remove(control);
        return true;
    }
}