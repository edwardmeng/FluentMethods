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
    public static void Each(this Array array, Action<object, int[]> action)
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
        var walker = new ArrayTraverse(array);
        while (walker.Step())
        {
            action(array.GetValue(walker.Position), walker.Position);
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
    public static void Each(this Array array, Action<object> action)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        array.Each((element, indices) => action(element));
    }

    private class ArrayTraverse
    {
        private readonly int[] _position;
        private readonly int[] _maxLengths;
        private readonly long _longLength;
        private long _index = -1;

        public ArrayTraverse(Array array)
        {
            _longLength = array.LongLength;
            _maxLengths = new int[array.Rank];
            _position = new int[array.Rank];
            for (int i = 0; i < array.Rank; ++i)
            {
                _maxLengths[i] = array.GetLength(i);
            }
        }

        public int[] Position
        {
            get { return _position; }
        }

        public bool Step()
        {
            if (_longLength == 0) return false;
            _index++;
            if (_index >= _longLength)
            {
                return false;
            }
            if (_index == 0) return true;
            _position[0]++;
            for (int i = 0; i < _position.Length; i++)
            {
                if (_position[i] < _maxLengths[i]) break;
                _position[i] = 0;
                _position[i + 1]++;
            }
            return true;
        }
    }
}