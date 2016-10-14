using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public static partial class Extensions
{
    private static async Task SendFileAsync(this HttpContextBase context, string fileName, string contentType, Func<HttpResponseBase, CancellationToken, Task> writer, CancellationToken token)
    {
        context.Response.Clear();
        context.Response.AddHeader("content-disposition", $"attachment; filename=\"{context.EncodeFileName(fileName)}\"");
        context.Response.ContentType = ResolveContentType(contentType);
        await writer(context.Response, token);
        context.Response.End();
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContextBase context, Stream stream, string fileName, string contentType, CancellationToken token)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        await context.SendFileAsync(fileName, contentType, async (response, cancellationToken) => await stream.CopyToAsync(response.OutputStream, 0x14000, cancellationToken), token);
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContextBase context, Stream stream, string fileName, string contentType)
    {
        await context.SendFileAsync(stream, fileName, contentType, CancellationToken.None);
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContextBase context, Stream stream, string fileName, CancellationToken token)
    {
        await context.SendFileAsync(stream, fileName, null, token);
    }

    /// <summary>
    /// A HttpContextBase extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContextBase"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContextBase context, Stream stream, string fileName)
    {
        await context.SendFileAsync(stream, fileName, CancellationToken.None);
    }
}