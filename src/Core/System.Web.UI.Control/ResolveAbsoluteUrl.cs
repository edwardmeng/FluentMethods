using System;
using System.Web;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Resolves the revlative URL to the absolute URL.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <param name="relativeUrl">The relative URL.</param>
    /// <returns>The absolute URL.</returns>
    public static string ResolveAbsoluteUrl(this Control control, string relativeUrl)
    {
        if (relativeUrl == null)
        {
            throw new ArgumentNullException(nameof(relativeUrl));
        }
        return (HttpContext.Current.Request.IsSecureConnection ? "https://" : "http://") +
            HttpContext.Current.Request.Url.Authority +
            control.ResolveUrl(relativeUrl);
    }
}