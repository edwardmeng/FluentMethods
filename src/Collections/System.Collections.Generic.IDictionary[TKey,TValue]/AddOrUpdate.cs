using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exist, 
    /// or updates a key/value pair in the <see cref="IDictionary{TKey, TValue}"/> if the key already exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to add or update element.</param>
    /// <param name="key">The key of the element to add or update.</param>
    /// <param name="value">The value of the element to add or update.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="dictionary"/> or <paramref name="key"/> is <see langword="null"/>.
    /// </exception>
    public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
        }
        else
        {
            dictionary[key] = value;
        }
    }

    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exist, 
    /// or updates a key/value pair in the <see cref="IDictionary{TKey, TValue}"/> if the key already exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to add or update element.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValue">The value to be added for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's
    ///     existing value.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
    public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, addValue);
        }
        else
        {
            dictionary[key] = updateValueFactory(key, dictionary[key]);
        }
    }

    /// <summary>
    /// Adds a key/value pair to the <see cref="IDictionary{TKey, TValue}"/> if the key does not already exist, 
    /// or updates a key/value pair in the <see cref="IDictionary{TKey, TValue}"/> if the key already exists.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to add or update element.</param>
    /// <param name="key">The key to be added or whose value should be updated.</param>
    /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
    /// <param name="updateValueFactory">
    ///     The function used to generate a new value for an existing key based on the key's
    ///     existing value.
    /// </param>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
    public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, addValueFactory(key));
        }
        else
        {
            dictionary[key] = updateValueFactory(key, dictionary[key]);
        }
    }
}