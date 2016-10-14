using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    /// <summary>
    /// Removes CSS class from a <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to remove the CSS class from.</param>
    /// <param name="className">The name of the CSS class to remove.</param>
    public static void RemoveCssClass(this Control control, string className)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        if (string.IsNullOrEmpty(className)) return;
        Func<string, string, string> removeCssClasses =
            (cssClass1, cssClass2) =>
                string.Join(" ", (cssClass1 ?? string.Empty)
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Except((cssClass2 ?? string.Empty).Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)));
        var webControl = control as WebControl;
        if (webControl != null)
        {
            webControl.CssClass = removeCssClasses(webControl.CssClass, className);
        }
        var htmlControl = control as HtmlControl;
        if (htmlControl != null)
        {
            htmlControl.Attributes["class"] = removeCssClasses(htmlControl.Attributes["class"], className);
        }
    }
}