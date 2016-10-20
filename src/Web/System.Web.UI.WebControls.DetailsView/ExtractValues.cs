using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    private static readonly MethodInfo _methodDetailsViewExtractRowValues = typeof(DetailsView).GetMethod("ExtractRowValues",
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new[] {typeof(IOrderedDictionary), typeof(bool), typeof(bool)}, null);

    /// <summary>
    /// Retrieves the values of each field declared within the details view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.DetailsView"/> from which to retrieve the field values.</param>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    public static void ExtractValues(this DetailsView control, IOrderedDictionary fieldValues, bool includeKeys)
    {
        if (control == null)
        {
            throw new ArgumentNullException(nameof(control));
        }
        if (fieldValues == null)
        {
            throw new ArgumentNullException(nameof(fieldValues));
        }
        _methodDetailsViewExtractRowValues.Invoke(control, new object[] { fieldValues, includeKeys });
        if (includeKeys && control.DataKeyNames.Length > 0)
        {
            foreach (string dataKeyName in control.DataKeyNames)
            {
                if (!fieldValues.Contains(dataKeyName))
                {
                    fieldValues.Add(dataKeyName, control.DataKey[dataKeyName]);
                }
            }
        }
    }

    /// <summary>
    /// Retrieves the values of each field declared within the details view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.DetailsView"/> from which to retrieve the field values.</param>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</param>
    public static void ExtractValues(this DetailsView control, IOrderedDictionary fieldValues)
    {
        control.ExtractValues(fieldValues, true);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the details view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.DetailsView"/> from which to retrieve the field values.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    /// <returns>An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</returns>
    public static IOrderedDictionary ExtractValues(this DetailsView control, bool includeKeys)
    {
        var fieldValues = new OrderedDictionary();
        control.ExtractValues(fieldValues, includeKeys);
        return fieldValues;
    }

    /// <summary>
    /// Retrieves the values of each field declared within the details view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.DetailsView"/> from which to retrieve the field values.</param>
    /// <returns>An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</returns>
    public static IOrderedDictionary ExtractValues(this DetailsView control)
    {
        return control.ExtractValues(true);
    }
}