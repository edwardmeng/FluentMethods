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
        if (array.LongLength == 0) return;
        var traverser = new ArrayTraverse(array);
        while (traverser.Step())
        {
            action(array.GetValue(traverser.Position), traverser.Position);
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
        private readonly int[] _maxLengths;
        private readonly long _longLength;
        private long _index = -1;

        public ArrayTraverse(Array array)
        {
            _longLength = array.LongLength;
            _maxLengths = new int[array.Rank];
            Position = new int[array.Rank];
            for (int i = 0; i < array.Rank; ++i)
            {
                _maxLengths[i] = array.GetLength(i);
            }
        }

        public int[] Position { get; }

        public bool Step()
        {
            if (_longLength == 0) return false;
            _index++;
            if (_index >= _longLength)
            {
                return false;
            }
            if (_index == 0) return true;
            Position[0]++;
            for (int i = 0; i < Position.Length; i++)
            {
                if (Position[i] < _maxLengths[i]) break;
                Position[i] = 0;
                Position[i + 1]++;
            }
            return true;
        }
    }
}