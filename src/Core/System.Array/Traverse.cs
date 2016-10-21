using System;

public static partial class Extensions
{
    /// <summary>
    /// Performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    public static void Traverse(this Array array, Action<object, int[]> action)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
#if NetCore
        if (array.Length == 0) return;
#else
        if (array.LongLength == 0) return;
#endif
        var traverser = new ArrayTraverse(array);
        while (traverser.MoveNext())
        {
            action(array.GetValue(traverser.Indices), traverser.Indices);
        }
    }

    /// <summary>
    /// Performs an action for each item in the array.
    /// </summary>
    /// <param name="array">The array that the action to be performed for.</param>
    /// <param name="action">The action to be performed.</param>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="array"/> or <paramref name="action"/> is <see langword="null" />.
    /// </exception>
    public static void Traverse(this Array array, Action<object> action)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        array.Traverse((element, indices) => action(element));
    }

    private class ArrayTraverse
    {
        private readonly int[] _upperBounds;
        private readonly int[] _lowerBounds;
        private readonly long _longLength;
        private long _index = -1;

        public ArrayTraverse(Array array)
        {
#if NetCore
            _longLength = array.Length;
#else
            _longLength = array.LongLength;
#endif
            _lowerBounds = new int[array.Rank];
            _upperBounds = new int[array.Rank];
            Indices = new int[array.Rank];
            for (int i = 0; i < array.Rank; ++i)
            {
                _lowerBounds[i] = array.GetLowerBound(i);
                _upperBounds[i] = array.GetUpperBound(i);
                Indices[i] = _lowerBounds[i];
            }
            Indices[Indices.Length - 1]--;
        }

        public int[] Indices { get; }

        public bool MoveNext()
        {
            if (_longLength == 0) return false;
            _index++;
            if (_index >= _longLength) return false;
            Indices[Indices.Length - 1]++;
            for (var i = Indices.Length - 1; i >=0; i--)
            {
                if (Indices[i] <= _upperBounds[i]) break;
                if (i == 0) return false;
                Indices[i] = _lowerBounds[i];
                Indices[i - 1]++;
            }
            return true;
        }
    }
}