using System.Linq;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Toggles CSS class of a <see cref="Control"/>.
    /// </summary>
    /// <param name="control">The <see cref="Control"/> object to toggle the CSS class.</param>
    /// <param name="className">The name of the CSS class to toggle.</param>
    public static void ToggleCssClass(this Control control, string className)
    {
        if (string.IsNullOrEmpty(className)) return;
        ModifyCssClass(control, originClassNames =>
        {
            var classNames = originClassNames.Distinct().ToList();
            foreach (var togglingClassName in SplitCssClasses(className).Distinct())
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
            return classNames.ToArray();
        });
    }
}