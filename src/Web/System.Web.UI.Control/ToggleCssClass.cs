using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    /// <summary>
    /// Toggles CSS class of a <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to toggle the CSS class.</param>
    /// <param name="className">The name of the CSS class to toggle.</param>
    public static void ToggleCssClass(this Control control, string className)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        if (string.IsNullOrEmpty(className)) return;
        Func<string, string, string> toggleCssClasses = (cssClass1, cssClass2) =>
        {
            var classNames = (cssClass1 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var togglingClassNames = (cssClass2 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
            foreach (var togglingClassName in togglingClassNames)
            {
                var index = classNames.IndexOf(togglingClassName);
                if (index != -1)
                {
                    classNames.RemoveAt(index);
                }
                else
                {
                    classNames.Add(togglingClassName);
                }
            }
            return string.Join(" ", classNames.ToArray());
        };
        var webControl = control as WebControl;
        if (webControl != null)
        {
            webControl.CssClass = toggleCssClasses(webControl.CssClass, className);
        }
        var htmlControl = control as HtmlControl;
        if (htmlControl != null)
        {
            htmlControl.Attributes["class"] = toggleCssClasses(htmlControl.Attributes["class"], className);
        }
    }
}