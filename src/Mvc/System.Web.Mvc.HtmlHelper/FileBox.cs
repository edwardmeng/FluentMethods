using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

public static partial class Extensions
{
    /// <summary>
    /// Returns a file input element by using the specified HTML helper and the name of the form field.
    /// </summary>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="name">The name of the form field and the <see cref="System.Web.Mvc.ViewDataDictionary"/> that is used to look up the validation errors.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBox(this HtmlHelper htmlHelper, string name)
    {
        return htmlHelper.FileBox(name, null);
    }

    /// <summary>
    /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
    /// </summary>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="name">The name of the form field and the <see cref="System.Web.Mvc.ViewDataDictionary"/> that is used to look up the validation errors.</param>
    /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBox(this HtmlHelper htmlHelper, string name, object htmlAttributes)
    {
        return htmlHelper.FileBox(name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Returns a file input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
    /// </summary>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="name">The name of the form field and the <see cref="System.Web.Mvc.ViewDataDictionary"/> that is used to look up the validation errors.</param>
    /// <param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBox(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
    {
        return FileBoxHelper(htmlHelper, name, htmlAttributes);
    }

    /// <summary>
    /// Returns a file input element for each property in the object that is represented by the specified expression.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the value.</typeparam>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
        return htmlHelper.FileBoxFor(expression, null);
    }

    /// <summary>
    /// Returns a file input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the value.</typeparam>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
    /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
    {
        return htmlHelper.FileBoxFor(expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Returns a file input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TProperty">The type of the value.</typeparam>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
    /// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
    /// <returns>An input element that has its type attribute set to "file".</returns>
    public static MvcHtmlString FileBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
    {
        return FileBoxHelper(htmlHelper, ExpressionHelper.GetExpressionText(expression), htmlAttributes);
    }

    private static MvcHtmlString FileBoxHelper(HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
    {
        string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        if (string.IsNullOrEmpty(fullHtmlFieldName))
        {
            throw new ArgumentException("The argument cannot be null or empty.", nameof(name));
        }
        var tagBuilder = new TagBuilder("input");
        tagBuilder.MergeAttributes(htmlAttributes);
        tagBuilder.MergeAttribute("type", "file", true);
        tagBuilder.MergeAttribute("name", fullHtmlFieldName, true);
        ModelState modelState;
        if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState))
        {
            if (modelState.Errors.Count > 0)
            {
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
        }

        return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
    }
}