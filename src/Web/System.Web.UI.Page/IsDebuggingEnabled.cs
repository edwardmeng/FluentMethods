using System;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

public static partial class Extensions
{
    private static Type _scriptManagerType;
    private static PropertyInfo _propertyIsDebuggingEnabled;

    private static object GetScriptManager(Page page)
    {
        if (_scriptManagerType == null)
        {
            _scriptManagerType = BuildManager.GetType("System.Web.UI.ScriptManager", false);
        }
        if (_scriptManagerType == null) return null;
        return page.Items[_scriptManagerType];
    }

    /// <summary>
    /// Gets a value indicating whether the current HTTP request is in debug mode.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the request is in debug mode; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsDebuggingEnabled(this Page page)
    {
        var scriptManager = GetScriptManager(page);
        if (scriptManager != null)
        {
            if (_propertyIsDebuggingEnabled == null)
            {
                _propertyIsDebuggingEnabled = _scriptManagerType.GetProperty("IsDebuggingEnabled");
            }
            if (_propertyIsDebuggingEnabled!=null)
            {
                return (bool) _propertyIsDebuggingEnabled.GetValue(scriptManager);
            }
        }
        return HttpContext.Current.IsDebuggingEnabled;
    }
}