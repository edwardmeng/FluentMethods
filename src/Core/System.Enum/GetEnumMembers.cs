using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static partial class Extensions
{
    private class EnumFieldDescriptor : MemberDescriptor
    {
        #region Fields

        private readonly FieldInfo _field;
        private string _category;
        private string _description;
        private string _displayName;

        #endregion

        public EnumFieldDescriptor(FieldInfo field) : base(field.Name)
        {
            _field = field;
        }

        protected override void FillAttributes(IList attributeList)
        {
            base.FillAttributes(attributeList);
            foreach (var attribute in Attribute.GetCustomAttributes(_field))
            {
                attributeList.Add(attribute);
            }
        }

        public override string Category
        {
            get
            {
                if (_category == null)
                {
                    _category = ((CategoryAttribute)Attributes[typeof(CategoryAttribute)])?.Category;
                    if (string.IsNullOrEmpty(_category))
                    {
                        _category = ((DisplayAttribute)Attributes[typeof(DisplayAttribute)])?.GetGroupName() ?? string.Empty;
                    }
                }
                return _category;
            }
        }

        public override string Description
        {
            get
            {
                if (_description == null)
                {
                    _description = ((DescriptionAttribute)Attributes[typeof(DescriptionAttribute)])?.Description;
                    if (string.IsNullOrEmpty(_description))
                    {
                        _description = ((DisplayAttribute)Attributes[typeof(DisplayAttribute)])?.GetDescription() ?? string.Empty;
                    }
                }
                return _description;
            }
        }

        public override string DisplayName
        {
            get
            {
                if (_displayName == null)
                {
                    _displayName = ((DisplayNameAttribute)Attributes[typeof(DisplayNameAttribute)])?.DisplayName;
                    if (string.IsNullOrEmpty(_displayName))
                    {
                        _displayName = ((DisplayAttribute)Attributes[typeof(DisplayAttribute)])?.GetName() ?? string.Empty;
                    }
                }
                return _displayName;
            }
        }

        public object GetValue()
        {
            return _field.GetValue(null);
        }
    }

    private static readonly Hashtable _typeMembersCache = new Hashtable();
    private static readonly Hashtable _enumMembersCache = new Hashtable();

    /// <summary>
    ///     Get the member descriptor of the specified enumeration value.
    /// </summary>
    /// <param name="enum">The <see cref="System.Enum"/> to act on.</param>
    /// <returns>The member descriptor of the specified enumeration value.</returns>
    public static MemberDescriptor GetEnumMember(this Enum @enum)
    {
        return @enum.GetEnumMembers().First();
    }

    /// <summary>
    ///     Get the member descriptors of the specified enumeration value.
    /// </summary>
    /// <param name="enum">The <see cref="System.Enum"/> to act on.</param>
    /// <returns>The members descriptor collection.</returns>
    public static IEnumerable<MemberDescriptor> GetEnumMembers(this Enum @enum)
    {
        lock (_enumMembersCache.SyncRoot)
        {
            if (!_enumMembersCache.ContainsKey(@enum))
            {
                _enumMembersCache.Add(@enum, @enum.GetType().GetEnumMembers().Where(member=> @enum.HasFlag((Enum)((EnumFieldDescriptor)member).GetValue())).ToArray());
            }
            return (IEnumerable<MemberDescriptor>) _enumMembersCache[@enum];
        }
    }

    /// <summary>
    ///     Get the member descriptors of the specified enumeration type.
    /// </summary>
    /// <param name="type">The <see cref="System.Type"/> to act on.</param>
    /// <returns>The members descriptor collection.</returns>
    public static IEnumerable<MemberDescriptor> GetEnumMembers(this Type type)
    {
        lock (_typeMembersCache.SyncRoot)
        {
            if (!_typeMembersCache.ContainsKey(type))
            {
                _typeMembersCache.Add(type, type.GetFields(BindingFlags.Static | BindingFlags.Public).Select(field => new EnumFieldDescriptor(field)).ToArray());
            }
            return (IEnumerable<MemberDescriptor>)_typeMembersCache[type];
        }
    }
}