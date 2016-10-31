using System;
using System.Xml;

public static partial class Extensions
{
    /// <summary>
    /// Add a CDATA child element for the <paramref name="node"/> with the specified value.
    /// </summary>
    /// <param name="node">>The <see cref="XmlNode"/> to add child element.</param>
    /// <param name="value">The value of the new element.</param>
    /// <returns>The CDATA child element.</returns>
    public static XmlCDataSection AppendCData(this XmlNode node, string value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }
        var section = (node.OwnerDocument ?? (XmlDocument)node).CreateCDataSection(value);
        node.AppendChild(section);
        return section;
    }
}
