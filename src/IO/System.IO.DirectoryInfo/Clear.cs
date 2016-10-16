using System;
using System.IO;

public static partial class Extensions
{
    /// <summary>
    ///     A <see cref="DirectoryInfo"/> extension method that clears all files and directories in this directory.
    /// </summary>
    /// <param name="directory">The directory to act on.</param>
    public static void Clear(this DirectoryInfo directory)
    {
        Array.ForEach(directory.GetFiles(), x => x.Delete());
        Array.ForEach(directory.GetDirectories(), x => x.Delete(true));
    }
}