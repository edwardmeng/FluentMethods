using System.IO;

public static partial class Extensions
{
    /// <summary>
    ///     A <see cref="DirectoryInfo"/> extension method that clears all files and directories in this directory.
    /// </summary>
    /// <param name="directory">The directory to act on.</param>
    public static void Clear(this DirectoryInfo directory)
    {
        foreach (var file in directory.GetFiles())
        {
            file.Delete();
        }
        foreach (var dir in directory.GetDirectories())
        {
            dir.Delete(true);
        }
    }
}