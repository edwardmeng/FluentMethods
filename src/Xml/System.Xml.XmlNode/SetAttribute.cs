using System;
using System.Xml;

public static partial class Extensions
{
    /// <summary>
    /// Set the attribute of a <see cref="XmlNode"/> with the specified value.
    /// </summary>
    /// <param name="node">The <see cref="XmlNode"/> to set attribute value.</param>
    /// <param name="name">The name of the attribute to be set.</param>
    /// <param name="value">The value of the attribute to set.</param>
    /// <exception cref="ArgumentNullException"><paramref name="node"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="name"/>is <see langword="null"/> or empty("").</exception>
    public static void SetAttribute(this XmlNode node, string name, string value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (node.Attributes == null) return;
        var attr = node.Attributes[name];
        if (attr != null)
        {
            attr.Value = value;
        }
        else
        {
            attr = node.OwnerDocument?.CreateAttribute(name);
            if (attr != null)
            {
                attr.Value = value;
                node.Attributes.Append(attr);
            }
        }
    }
}
