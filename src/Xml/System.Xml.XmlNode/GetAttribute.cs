using System;
using System.Xml;

public static partial class Extensions
{
    /// <summary>
    /// Read attribute value from the <paramref name="node"/> with the specified attribute name.
    /// </summary>
    /// <param name="node">The <see cref="XmlNode"/> to read attribute value from.</param>
    /// <param name="name">The name of the attribute to read.</param>
    /// <returns>
    /// The value of the attribute <paramref name="name"/> from the <paramref name="node"/>. 
    /// If the <paramref name="node"/> does not contain the attribute <paramref name="name"/>,
    /// it will returns <see langword="null"/>. 
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is <see langword="null"/>.</exception>
    public static string GetAttribute(this XmlNode node, string name)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        return node.Attributes?.GetNamedItem(name)?.Value;
    }
}
