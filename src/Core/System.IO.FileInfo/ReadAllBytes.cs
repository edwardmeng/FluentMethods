using System.IO;

public static partial class Extensions
{
    /// <summary>
    ///     Opens a binary file, reads the contents of the file into a byte array, and then closes the file.
    /// </summary>
    /// <param name="file">The file to open for reading.</param>
    /// <returns>A byte array containing the contents of the file.</returns>
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
    ///     <paramref name="file" /> is null.
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
    ///     This operation is not supported on the current
    ///     platform.-or- <paramref name="file" /> specified a directory.-or- The caller does not have the required
    ///     permission.
    /// </exception>
    /// ###
    /// <exception cref="T:System.IO.FileNotFoundException">
    ///     The file specified in <paramref name="file" /> was not
    ///     found.
    /// </exception>
    /// ###
    /// <exception cref="T:System.NotSupportedException">
    ///     <paramref name="file" /> is in an invalid format.
    /// </exception>
    /// ###
    /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
    public static byte[] ReadAllBytes(this FileInfo file)
    {
        return File.ReadAllBytes(file.FullName);
    }
}