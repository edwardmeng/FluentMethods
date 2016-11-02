using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    private static string[] SplitCssClasses(string cssClassString)
    {
        return (cssClassString ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private static void ModifyCssClass(Control control, Func<string[], string[]> modifier)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        var webControl = control as WebControl;
        if (webControl != null)
        {
            webControl.CssClass = string.Join(" ", modifier(SplitCssClasses(webControl.CssClass)));
        }
        var htmlControl = control as HtmlControl;
        if (htmlControl != null)
        {
            htmlControl.Attributes["class"] = string.Join(" ", modifier(SplitCssClasses(htmlControl.Attributes["class"])));
        }
    }

    /// <summary>
    /// Adds CSS class to a <see cref="Control"/> if the css class is not already part of the <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to add the CSS class to.</param>
    /// <param name="className">The name of the CSS class to add.</param>
    public static void AddCssClass(this Control control, string className)
    {
        if (string.IsNullOrEmpty(className)) return;
        ModifyCssClass(control, originClassNames => originClassNames.Union(SplitCssClasses(className)));
    }
}