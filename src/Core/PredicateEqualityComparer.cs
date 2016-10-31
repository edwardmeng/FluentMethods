using System;
using System.Collections.Generic;

/// <summary>
/// <see cref="EqualityComparer{T}" /> that uses a predicate to compare objects.
/// </summary>
/// <typeparam name="T">The type of objects to compare.</typeparam>
internal class PredicateEqualityComparer<T> : EqualityComparer<T>
{
    /// <summary>
    /// The predicate.
    /// </summary>
    private readonly Func<T, T, bool> _predicate;

    /// <summary>
    /// Initializes a new instance of the <see cref="PredicateEqualityComparer&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="predicate"/> is <see langword="null" />.
    /// </exception>
    public PredicateEqualityComparer(Func<T, T, bool> predicate)
    {
        _predicate = predicate;
    }

    /// <summary>
    /// Determines whether the specified objects are equal.
    /// </summary>
    /// <param name="x">The first object of type <typeparamref name="T"/> to compare.</param>
    /// <param name="y">The second object of type <typeparamref name="T"/> to compare.</param>
    /// <returns><see langword="true" /> if the specified objects are equal; otherwise <see langword="false" />.</returns>
    public override bool Equals(T x, T y)
    {
        return !ReferenceEquals(x, null)
                   ? !ReferenceEquals(y, null) && _predicate(x, y)
                   : ReferenceEquals(y, null);
    }

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <param name="obj">The object for which to get a hash code.</param>
    /// <returns>
    /// Always return the same value to force the call to <see cref="IEqualityComparer&lt;T&gt;" />.Equals.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// The type of <paramref name="obj"/> is a reference and <paramref name="obj"/> is <see langword="null"/>.
    /// </exception>
    public override int GetHashCode(T obj)
    {
        return 0;
    }
}
