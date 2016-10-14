using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// A HttpContext extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static Task SendFileAsync(this HttpContext context, Stream stream, string fileName, string contentType, CancellationToken token)
    {
        return new HttpContextWrapper(context).SendFileAsync(stream,fileName,contentType,token);
    }

    /// <summary>
    /// A HttpContext extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="contentType">The content type of the output file. Default to download the output file anyway.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContext context, Stream stream, string fileName, string contentType)
    {
        await context.SendFileAsync(stream, fileName, contentType, CancellationToken.None);
    }

    /// <summary>
    /// A HttpContext extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContext context, Stream stream, string fileName, CancellationToken token)
    {
        await context.SendFileAsync(stream, fileName, null, token);
    }

    /// <summary>
    /// A HttpContext extension method that sends a file asynchronously.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> to act on.</param>
    /// <param name="stream">The stream to file.</param>
    /// <param name="fileName">The file name of the output file.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    public static async Task SendFileAsync(this HttpContext context, Stream stream, string fileName)
    {
        await context.SendFileAsync(stream, fileName, CancellationToken.None);
    }
}