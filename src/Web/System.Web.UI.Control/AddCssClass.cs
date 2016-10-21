using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    /// <summary>
    /// Adds CSS class to a <see cref="Control"/> if the css class is not already part of the <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to add the CSS class to.</param>
    /// <param name="className">The name of the CSS class to add.</param>
    public static void AddCssClass(this Control control, string className)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        if (string.IsNullOrEmpty(className)) return;
        Func<string, string, string> mergeCssClasses = (cssClass1, cssClass2) => 
            string.Join(" ",(cssClass1 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Union((cssClass2 ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
        var webControl = control as WebControl;
        if (webControl != null)
        {
            webControl.CssClass = mergeCssClasses(webControl.CssClass, className);
        }
        var htmlControl = control as HtmlControl;
        if (htmlControl != null)
        {
            htmlControl.Attributes["class"] = mergeCssClasses(htmlControl.Attributes["class"], className);
        }
    }
}