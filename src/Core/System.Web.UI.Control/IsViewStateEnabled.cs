using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Gets a value indicating whether the view state is enabled for the control.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the request is in debug mode; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsViewStateEnabled(this Control control)
    {
        while (control != null)
        {
            if (!control.EnableViewState) return false;
#if !Net35
            var viewStateMode = control.ViewStateMode;
            if (viewStateMode != ViewStateMode.Inherit) return viewStateMode == ViewStateMode.Enabled;
#endif
            control = control.Parent;
        }
        return true;
    }
}