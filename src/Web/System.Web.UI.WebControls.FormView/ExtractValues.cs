using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    private static readonly MethodInfo _methodFormViewExtractRowValues = typeof(FormView).GetMethod("ExtractRowValues", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    /// <summary>
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</param>
    /// <param name="includeReadOnlyFields"><c>true</c> to include read-only fields; otherwise, <c>false</c>.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    public static void ExtractValues(this FormView control, IOrderedDictionary fieldValues, bool includeReadOnlyFields, bool includeKeys)
    {
        if (control == null)
        {
            throw new ArgumentNullException(nameof(control));
        }
        if (fieldValues == null)
        {
            throw new ArgumentNullException(nameof(fieldValues));
        }
        _methodFormViewExtractRowValues.Invoke(control, new object[] { fieldValues, includeKeys });
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
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    public static void ExtractValues(this FormView control, IOrderedDictionary fieldValues, bool includeKeys)
    {
        control.ExtractValues(fieldValues, true, includeKeys);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</param>
    public static void ExtractValues(this FormView control, IOrderedDictionary fieldValues)
    {
        control.ExtractValues(fieldValues, true);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <param name="includeReadOnlyFields"><c>true</c> to include read-only fields; otherwise, <c>false</c>.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    /// <returns>An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</returns>
    public static IOrderedDictionary ExtractValues(this FormView control, bool includeReadOnlyFields, bool includeKeys)
    {
        var fieldValues = new OrderedDictionary();
        control.ExtractValues(fieldValues, includeReadOnlyFields, includeKeys);
        return fieldValues;
    }

    /// <summary>
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <param name="includeKeys"><c>true</c> to include key fields; otherwise, <c>false</c>.</param>
    /// <returns>An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</returns>
    public static IOrderedDictionary ExtractValues(this FormView control, bool includeKeys)
    {
        return control.ExtractValues(true, includeKeys);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the form view and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="control">The <see cref="System.Web.UI.WebControls.FormView"/> from which to retrieve the field values.</param>
    /// <returns>An <see cref="IOrderedDictionary"/> used to store the field values of the current data item.</returns>
    public static IOrderedDictionary ExtractValues(this FormView control)
    {
        return control.ExtractValues(true);
    }
}