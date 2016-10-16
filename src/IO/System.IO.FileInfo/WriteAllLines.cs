using System.Collections.Generic;
using System.IO;
using System.Text;

public static partial class Extensions
{
    /// <summary>
    ///     Creates a new file, write the specified string array to the file, and then closes the file.
    /// </summary>
    /// <param name="file">The file to write to.</param>
    /// <param name="contents">The string array to write to the file.</param>
    /// ###
    /// <exception cref="T:System.ArgumentException">
    ///     <paramref name="file" /> is a zero-length string, contains only
    ///     white space, or contains one or more invalid characters as defined by
    ///     <see
    ///         cref="M:System.IO.Path.InvalidPathChars" />
    ///     .
    /// </exception>
    /// ###
    /// <exception cref="T:System.ArgumentNullException">
    ///     Either <paramref name="file" /> or
    ///     <paramref name="contents" /> is null.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.PathTooLongException">
    ///     The specified @file, file name, or both exceed the system-
    ///     defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file
    ///     names must be less than 260 characters.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.DirectoryNotFoundException">
    ///     The specified @file is invalid (for example, it is on
    ///     an unmapped drive).
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
    /// ###
    /// <exception cref="T:System.UnauthorizedAccessException">
    ///     <paramref name="file" /> specified a file that is
    ///     read-only.-or- This operation is not supported on the current platform.-or-
    ///     <paramref
    ///         name="file" />
    ///     specified a directory.-or- The caller does not have the required permission.
    /// </exception>
    /// ###
    /// <exception cref="T:System.NotSupportedException">
    ///     <paramref name="file" /> is in an invalid format.
    /// </exception>
    /// ###
    /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
    public static void WriteAllLines(this FileInfo file, string[] contents)
    {
        File.WriteAllLines(file.FullName, contents);
    }

    /// <summary>
    ///     Creates a new file, writes the specified string array to the file by using the specified encoding, and then
    ///     closes the file.
    /// </summary>
    /// <param name="file">The file to write to.</param>
    /// <param name="contents">The string array to write to the file.</param>
    /// <param name="encoding">
    ///     An <see cref="T:System.Text.Encoding" /> object that represents the character encoding
    ///     applied to the string array.
    /// </param>
    /// ###
    /// <exception cref="T:System.ArgumentException">
    ///     <paramref name="file" /> is a zero-length string, contains only
    ///     white space, or contains one or more invalid characters as defined by
    ///     <see
    ///         cref="M:System.IO.Path.InvalidPathChars" />
    ///     .
    /// </exception>
    /// ###
    /// <exception cref="T:System.ArgumentNullException">
    ///     Either <paramref name="file" /> or
    ///     <paramref name="contents" /> is null.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.PathTooLongException">
    ///     The specified @file, file name, or both exceed the system-
    ///     defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file
    ///     names must be less than 260 characters.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.DirectoryNotFoundException">
    ///     The specified @file is invalid (for example, it is on
    ///     an unmapped drive).
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.IOException">An I/O error occurred while opening the file.</exception>
    /// ###
    /// <exception cref="T:System.UnauthorizedAccessException">
    ///     <paramref name="file" /> specified a file that is
    ///     read-only.-or- This operation is not supported on the current platform.-or-
    ///     <paramref
    ///         name="file" />
    ///     specified a directory.-or- The caller does not have the required permission.
    /// </exception>
    /// ###
    /// <exception cref="T:System.NotSupportedException">
    ///     <paramref name="file" /> is in an invalid format.
    /// </exception>
    /// ###
    /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
    public static void WriteAllLines(this FileInfo file, string[] contents, Encoding encoding)
    {
        File.WriteAllLines(file.FullName, contents, encoding);
    }

    /// <summary>
    ///     Creates a new file, write the specified string array to the file, and then closes the file.
    /// </summary>
    /// <param name="file">The @file to act on.</param>
    /// <param name="contents">The string array to write to the file.</param>
    public static void WriteAllLines(this FileInfo file, IEnumerable<string> contents)
    {
        File.WriteAllLines(file.FullName, contents);
    }

    /// <summary>
    ///     Creates a new file, writes the specified string array to the file by using the specified encoding, and then
    ///     closes the file.
    /// </summary>
    /// <param name="file">The @file to act on.</param>
    /// <param name="contents">The string array to write to the file.</param>
    /// <param name="encoding">
    ///     An <see cref="T:System.Text.Encoding" /> object that represents the character encoding
    ///     applied to the string array.
    /// </param>
    public static void WriteAllLines(this FileInfo file, IEnumerable<string> contents, Encoding encoding)
    {
        File.WriteAllLines(file.FullName, contents, encoding);
    }
}