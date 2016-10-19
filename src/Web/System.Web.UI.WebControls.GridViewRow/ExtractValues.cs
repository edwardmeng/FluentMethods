using System.Collections.Specialized;
using System.Reflection;
using System.Web.UI.WebControls;

public static partial class Extensions
{
    private static readonly MethodInfo _methodExtractRowValues = typeof(GridView).GetMethod("ExtractValues", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values.</param>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    /// <param name="includeReadOnlyFields"><c>true</c> to include read-only fields; otherwise, <c>false</c>.</param>
    /// <param name="includePrimaryKey"><c>true</c> to include the primary key field or fields; otherwise, <c>false</c>.</param>
    public static void ExtractValues(this GridViewRow row, IOrderedDictionary fieldValues, bool includeReadOnlyFields, bool includePrimaryKey)
    {
        var gridView = (GridView)row.NamingContainer;
        _methodExtractRowValues.Invoke(gridView, new object[] { fieldValues, row, includeReadOnlyFields, includePrimaryKey });
        if (includePrimaryKey && gridView.DataKeyNames.Length > 0 && gridView.DataKeys.Count > row.RowIndex)
        {
            var dataKey = gridView.DataKeys[row.RowIndex];
            if (dataKey != null)
            {
                foreach (string dataKeyName in gridView.DataKeyNames)
                {
                    if (!fieldValues.Contains(dataKeyName))
                    {
                        fieldValues.Add(dataKeyName, dataKey[dataKeyName]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values.</param>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    /// <param name="includePrimaryKey"><c>true</c> to include the primary key field or fields; otherwise, <c>false</c>.</param>
    public static void ExtractValues(this GridViewRow row, IOrderedDictionary fieldValues, bool includePrimaryKey)
    {
        row.ExtractValues(fieldValues, true, includePrimaryKey);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="fieldValues">An <see cref="IOrderedDictionary"/> used to store the field values.</param>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    public static void ExtractValues(this GridViewRow row, IOrderedDictionary fieldValues)
    {
        row.ExtractValues(fieldValues, true, true);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    /// <param name="includeReadOnlyFields"><c>true</c> to include read-only fields; otherwise, <c>false</c>.</param>
    /// <param name="includePrimaryKey"><c>true</c> to include the primary key field or fields; otherwise, <c>false</c>.</param>
    public static IOrderedDictionary ExtractValues(this GridViewRow row, bool includeReadOnlyFields, bool includePrimaryKey)
    {
        var fieldValues = new OrderedDictionary();
        row.ExtractValues(fieldValues,includeReadOnlyFields,includePrimaryKey);
        return fieldValues;
    }

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    /// <param name="includePrimaryKey"><c>true</c> to include the primary key field or fields; otherwise, <c>false</c>.</param>
    public static IOrderedDictionary ExtractValues(this GridViewRow row, bool includePrimaryKey)
    {
        return row.ExtractValues(true, includePrimaryKey);
    }

    /// <summary>
    /// Retrieves the values of each field declared within the specified row and stores them in the specified <see cref="IOrderedDictionary"/> object.
    /// </summary>
    /// <param name="row">The <see cref="System.Web.UI.WebControls.GridViewRow"/> from which to retrieve the field values.</param>
    public static IOrderedDictionary ExtractValues(this GridViewRow row)
    {
        return row.ExtractValues(true);
    }
}