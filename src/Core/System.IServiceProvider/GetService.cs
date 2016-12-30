using System;

public static partial class Extensions
{
    /// <summary>
    ///     Gets the service object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of service object to get. </typeparam>
    /// <param name="provider">The <see cref="IServiceProvider"/> to get service.</param>
    /// <returns>A service object of type <typeparamref name="T"/>.-or- null if there is no service object of type <typeparamref name="T"/>.</returns>
    public static T GetService<T>(this IServiceProvider provider) where T : class
    {
        return (T)provider.GetService(typeof(T));
    }
}