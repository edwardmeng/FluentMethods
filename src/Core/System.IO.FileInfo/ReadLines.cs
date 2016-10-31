using System.Collections.Generic;
using System.IO;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Reads the lines of a file.
    /// </summary>
    /// <param name="file">The file to read.</param>
    /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
    /// ###
    /// <exception cref="T:System.ArgumentException">
    ///     <paramref name="file" /> is a zero-length string, contains only
    ///     white space, or contains one or more invalid characters defined by the
    ///     <see
    ///         cref="M:System.IO.Path.GetInvalidPathChars" />
    ///     method.
    /// </exception>
    /// ###
    /// <exception cref="T:System.ArgumentNullException">
    ///     <paramref name="file" /> is null.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.DirectoryNotFoundException">
    ///     <paramref name="file" /> is invalid (for example, it
    ///     is on an unmapped drive).
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.FileNotFoundException">
    ///     The file specified by <paramref name="file" /> was not
    ///     found.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
    /// ###
    /// <exception cref="T:System.IO.PathTooLongException">
    ///     <paramref name="file" /> exceeds the system-defined
    ///     maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names
    ///     must be less than 260 characters.
    /// </exception>
    /// ###
    /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// ###
    /// <exception cref="T:System.UnauthorizedAccessException">
    ///     <paramref name="file" /> specifies a file that is
    ///     read-only.-or-This operation is not supported on the current platform.-or-
    ///     <paramref
    ///         name="file" />
    ///     is a directory.-or-The caller does not have the required permission.
    /// </exception>
    public static IEnumerable<string> ReadLines(this FileInfo file)
    {
        return File.ReadLines(file.FullName);
    }

    /// <summary>
    ///     Read the lines of a file that has a specified encoding.
    /// </summary>
    /// <param name="file">The file to read.</param>
    /// <param name="encoding">The encoding that is applied to the contents of the file.</param>
    /// <returns>All the lines of the file, or the lines that are the result of a query.</returns>
    /// ###
    /// <exception cref="T:System.ArgumentException">
    ///     <paramref name="file" /> is a zero-length string, contains only
    ///     white space, or contains one or more invalid characters as defined by the
    ///     <see
    ///         cref="M:System.IO.Path.GetInvalidPathChars" />
    ///     method.
    /// </exception>
    /// ###
    /// <exception cref="T:System.ArgumentNullException">
    ///     <paramref name="file" /> is null.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.DirectoryNotFoundException">
    ///     <paramref name="file" /> is invalid (for example, it
    ///     is on an unmapped drive).
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.FileNotFoundException">
    ///     The file specified by <paramref name="file" /> was not
    ///     found.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
    /// ###
    /// <exception cref="T:System.IO.PathTooLongException">
    ///     <paramref name="file" /> exceeds the system-defined
    ///     maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names
    ///     must be less than 260 characters.
    /// </exception>
    /// ###
    /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
    /// ###
    /// <exception cref="T:System.UnauthorizedAccessException">
    ///     <paramref name="file" /> specifies a file that is
    ///     read-only.-or-This operation is not supported on the current platform.-or-
    ///     <paramref
    ///         name="file" />
    ///     is a directory.-or-The caller does not have the required permission.
    /// </exception>
    public static IEnumerable<string> ReadLines(this FileInfo file, Encoding encoding)
    {
        return File.ReadLines(file.FullName, encoding);
    }
}