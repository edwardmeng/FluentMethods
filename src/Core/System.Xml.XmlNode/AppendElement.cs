using System;
using System.Xml;

public static partial class Extensions
{
    /// <summary>
    /// Add a new child element <paramref name="name"/> for the <paramref name="node"/>.
    /// </summary>
    /// <param name="node">>The <see cref="XmlNode"/> to add child element.</param>
    /// <param name="name">The name of the new child element.</param>
    /// <returns>The new child element.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/>is <see langword="null"/> or empty("").</exception>
    public static XmlNode AppendElement(this XmlNode node, string name)
    {
        return AppendElement(node, name, null);
    }

    /// <summary>
    /// Add a new child element for the <paramref name="node"/> with the specified element value.
    /// </summary>
    /// <param name="node">>The <see cref="XmlNode"/> to add child element.</param>
    /// <param name="name">The name of the new child element.</param>
    /// <param name="value">The value of the child element.</param>
    /// <returns>The new child element.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/>is <see langword="null"/> or empty("").</exception>
    public static XmlNode AppendElement(this XmlNode node, string name, string value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var document = node as XmlDocument;
        XmlNode childNode = null;
        if (document != null)
        {
            childNode = document.AppendChild(document.CreateElement(name));
        }
        else
        {
            document = node.OwnerDocument;
            if (document != null)
            {
                childNode = node.AppendChild(document.CreateElement(name));
            }
        }
        if (childNode != null && !string.IsNullOrEmpty(value))
        {
            childNode.AppendChild(document.CreateTextNode(value));
        }
        return childNode;
    }
}
