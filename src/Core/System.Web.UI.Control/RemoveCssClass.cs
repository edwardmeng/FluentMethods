using System.Linq;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Removes CSS class from a <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to remove the CSS class from.</param>
    /// <param name="className">The name of the CSS class to remove.</param>
    public static void RemoveCssClass(this Control control, string className)
    {
        if (string.IsNullOrEmpty(className)) return;
        ModifyCssClass(control, originClassNames => originClassNames.Except(SplitCssClasses(className)).ToArray());
    }
}