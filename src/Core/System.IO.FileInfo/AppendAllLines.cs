using System.Collections.Generic;
using System.IO;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     A FileInfo extension method that appends all lines.
    /// </summary>
    /// <param name="file">The file to act on.</param>
    /// <param name="contents">The contents.</param>
    public static void AppendAllLines(this FileInfo file, IEnumerable<string> contents)
    {
        File.AppendAllLines(file.FullName, contents);
    }

    /// <summary>
    ///     A FileInfo extension method that appends all lines.
    /// </summary>
    /// <param name="file">The file to act on.</param>
    /// <param name="contents">The contents.</param>
    /// <param name="encoding">The encoding.</param>
    public static void AppendAllLines(this FileInfo file, IEnumerable<string> contents, Encoding encoding)
    {
        File.AppendAllLines(file.FullName, contents, encoding);
    }
}