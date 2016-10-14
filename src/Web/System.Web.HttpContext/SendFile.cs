using System.IO;
using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="filePath">The full path to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, string filePath, string fileName = null, string contentType = null)
    {
        new HttpContextWrapper(context).SendFile(filePath,fileName,contentType);
    }

    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="buffer">The buffer to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, byte[] buffer, string fileName, string contentType = null)
    {
        new HttpContextWrapper(context).SendFile(buffer, fileName, contentType);
    }

    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="steam">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, Stream steam, string fileName, string contentType = null)
    {
        new HttpContextWrapper(context).SendFile(steam, fileName, contentType);
    }
}