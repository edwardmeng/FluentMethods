using System;
using System.Collections.Specialized;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves property values bound using two-way ASP.NET data-binding syntax within the templated content.
    /// </summary>
    /// <param name="control">
    /// The <see cref="Control"/> from which to extract property values, 
    /// which are passed by the data-bound control to an associated data source control in two-way data-binding scenarios.
    /// </param>
    /// <param name="component">
    /// The target component to set property values that retrieved from the data-bound control.
    /// </param>
    public static void ExtractValues(this IBindableControl control, object component)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        if (component == null) throw new ArgumentNullException(nameof(component));
        IOrderedDictionary fieldValues = new OrderedDictionary();
        control.ExtractValues(fieldValues);
        component.Bind(fieldValues);
    }

    /// <summary>
    /// Create a new component and retrieves property values bound using two-way ASP.NET data-binding syntax within the templated content.
    /// </summary>
    /// <typeparam name="T">The type of the component to be created.</typeparam>
    /// <param name="control">
    /// The <see cref="Control"/> from which to extract property values, 
    /// which are passed by the data-bound control to an associated data source control in two-way data-binding scenarios.
    /// </param>
    /// <returns>
    /// A new component that is set property values retrieved from the data-bound control.
    /// </returns>
    public static T ExtractValues<T>(this IBindableControl control)
             where T : new()
    {
        var component = new T();
        control.ExtractValues(component);
        return component;
    }
}