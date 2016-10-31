using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    /// <summary>
    /// Detects whether the <see cref="Control"/> is assigned the given class.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to detect the CSS class.</param>
    /// <param name="className">The name of the CSS class to detect.</param>
    /// <returns><c>true</c> if the <see cref="Control"/> is assigned the given class; otherwise, <c>false</c>.</returns>
    public static bool HasCssClass(this Control control, string className)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        if (string.IsNullOrEmpty(className)) return false;
        Func<string, string, bool> hasCssClasses = (cssClass1, cssClass2) =>
        {
            var classNames = (cssClass1 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var detectingClassNames = (cssClass2 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
            foreach (var detectingClassName in detectingClassNames)
            {
                if (!classNames.Contains(detectingClassName))
                {
                    return false;
                }
            }
            return true;
        };
        var webControl = control as WebControl;
        if (webControl != null)
        {
            return hasCssClasses(webControl.CssClass, className);
        }
        var htmlControl = control as HtmlControl;
        if (htmlControl != null)
        {
            return hasCssClasses(htmlControl.Attributes["class"], className);
        }
        return false;
    }
}