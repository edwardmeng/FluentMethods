using System;
using System.Web.UI;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a <see cref="Control"/>'s declared data item, indicating success or failure.
    /// </summary>
    /// <param name="control">
    /// The <see cref="Control"/> against which the expression is evaluated.
    /// </param>
    /// <param name="foundDataItem">
    /// A Boolean value that indicates whether the data item was successfully resolved and returned. 
    /// This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    /// An object that represents the control's declared data item. 
    /// Returns <see langword="null"/> if no data item is found.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="control"/> is <see langword="null"/>.</exception>
    public static object GetDataItem(this Control control, out bool foundDataItem)
    {
        if (control == null) throw new ArgumentNullException(nameof(control));
        foundDataItem = false;
        while (control != null)
        {
            var dataItem = DataBinder.GetDataItem(control, out foundDataItem);
            if (foundDataItem) return dataItem;
            control = control.Parent;
        }
        return null;
    }

    /// <summary>
    /// Retrieves a <see cref="Control"/>'s declared data item.
    /// </summary>
    /// <param name="control">
    /// The <see cref="Control"/> against which the expression is evaluated.
    /// </param>
    /// <returns>
    /// An object that represents the control's declared data item. 
    /// Returns <see langword="null"/> if no data item is found.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="control"/> is <see langword="null"/>.</exception>
    public static object GetDataItem(this Control control)
    {
        bool foundDataItem;
        return GetDataItem(control, out foundDataItem);
    }
}