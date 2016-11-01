using System;
using System.IO;
using System.Web;

public static partial class Extensions
{
    private static string ResolveContentType(string contentType)
    {
        if (string.IsNullOrEmpty(contentType))
        {
            contentType = "application/octet-stream;charset=utf-8";
        }
        return contentType;
    }

#if Net35

    private static string EncodeFileName(this HttpContext context, string fileName)
    {
        if (context.Request.Browser.IsBrowser("InternetExplorer"))
        {
            fileName = HttpUtility.UrlEncode(fileName);
        }
        return fileName;
    }

    private static void SendFile(this HttpContext context, string fileName, string contentType, Action<HttpResponse> writer)
    {
        context.Response.Clear();
        context.Response.AddHeader("content-disposition", $"attachment; filename=\"{context.EncodeFileName(fileName)}\"");
        context.Response.ContentType = ResolveContentType(contentType);
        writer(context.Response);
        context.Response.End();
    }

#endif
    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="filePath">The full path to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, string filePath, string fileName = null, string contentType = null)
    {
#if Net35
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        context.SendFile(string.IsNullOrEmpty(fileName) ? Path.GetFileName(filePath) : fileName, contentType, response => response.TransmitFile(filePath));
#else
        new HttpContextWrapper(context).SendFile(filePath, fileName, contentType);
#endif
    }

    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="buffer">The buffer to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, byte[] buffer, string fileName, string contentType = null)
    {
#if Net35
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }
        context.SendFile(fileName, contentType, response => response.BinaryWrite(buffer));
#else
        new HttpContextWrapper(context).SendFile(buffer, fileName, contentType);
#endif
    }

    /// <summary>
    /// A HttpContext extension method that sends a file.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    public static void SendFile(this HttpContext context, Stream stream, string fileName, string contentType = null)
    {
#if Net35
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        context.SendFile(fileName, contentType, response =>
        {
            int length;
            byte[] buffer = new byte[0x14000];
            while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                response.OutputStream.Write(buffer, 0, length);
            }
        });
#else
        new HttpContextWrapper(context).SendFile(stream, fileName, contentType);
#endif
    }
}