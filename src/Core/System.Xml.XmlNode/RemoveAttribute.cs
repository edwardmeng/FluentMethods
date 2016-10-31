using System;
using System.Xml;

public static partial class Extensions
{
    /// <summary>
    /// Remove the attribute from the <see cref="XmlNode"/> with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="node">The <see cref="XmlNode"/> to remove attribute from.</param>
    /// <param name="name">The name of the attribute to be removed.</param>
    /// <returns>The value of the removed attribute.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is <see langword="null"/>.</exception>
    public static string RemoveAttribute(this XmlNode node, string name)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        return node.Attributes?.RemoveNamedItem(name)?.Value;
    }
}
