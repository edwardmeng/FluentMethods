using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the given event with it
    /// </summary>
    /// <param name="il"></param>
    /// <param name="event">The event to remove the delegate instance from</param>
    public static ILGenerator RemoveFromEvent(this ILGenerator il, EventInfo @event)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));
        return il.Call(@event.RemoveMethod);
    }

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the event with the given
    ///     name on the given type
    /// </summary>
    /// <param name="il"></param>
    /// <param name="type">The type the event is on</param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator RemoveFromEvent(this ILGenerator il, Type type, string eventName)
        => il.RemoveFromEvent(GetEventInfo(type, eventName));

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the event with the given
    ///     name on the given type
    /// </summary>
    /// <typeparam name="T">The type the event is on</typeparam>
    /// <param name="il"></param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator RemoveFromEvent<T>(this ILGenerator il, string eventName)
        => il.RemoveFromEvent(typeof(T), eventName);
}