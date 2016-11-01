using System;
using System.IO;
using System.Web;

public static partial class Extensions
{
    private static string EncodeFileName(this HttpContextBase context, string fileName)
    {
        if (context.Request.Browser.IsBrowser("InternetExplorer"))
        {
            fileName = HttpUtility.UrlEncode(fileName);
        }
        return fileName;
    }

    private static void SendFile(this HttpContextBase context, string fileName, string contentType, Action<HttpResponseBase> writer)
    {
        context.Response.Clear();
        context.Response.AddHeader("content-disposition", $"attachment; filename=\"{context.EncodeFileName(fileName)}\"");
        context.Response.ContentType = ResolveContentType(contentType);
        writer(context.Response);
        context.Response.End();
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="filePath">The full path to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContextBase context, string filePath, string fileName = null, string contentType = null)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        context.SendFile(string.IsNullOrEmpty(fileName) ? Path.GetFileName(filePath) : fileName, contentType, response => response.TransmitFile(filePath));
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="buffer">The buffer to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContextBase context, byte[] buffer, string fileName, string contentType = null)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }
        context.SendFile(fileName, contentType, response => response.BinaryWrite(buffer));
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="steam">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContextBase context, Stream steam, string fileName, string contentType = null)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (steam == null)
        {
            throw new ArgumentNullException(nameof(steam));
        }
        context.SendFile(fileName, contentType, response => steam.CopyTo(response.OutputStream));
    }
}