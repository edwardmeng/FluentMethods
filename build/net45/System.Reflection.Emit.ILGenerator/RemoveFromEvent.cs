using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the given event with it
    /// </summary>
    /// <param name="generator"></param>
    /// <param name="event">The event to remove the delegate instance from</param>
    public static ILGenerator RemoveFromEvent(this ILGenerator generator, EventInfo @event)
    {
        if (generator == null)
            throw new ArgumentNullException(nameof(generator));
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));
        return generator.Call(@event.RemoveMethod);
    }

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the event with the given
    ///     name on the given type
    /// </summary>
    /// <param name="generator"></param>
    /// <param name="type">The type the event is on</param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator RemoveFromEvent(this ILGenerator generator, Type type, string eventName)
        => generator.RemoveFromEvent(GetEventInfo(type, eventName));

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the remover of the event with the given
    ///     name on the given type
    /// </summary>
    /// <typeparam name="T">The type the event is on</typeparam>
    /// <param name="generator"></param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator RemoveFromEvent<T>(this ILGenerator generator, string eventName)
        => generator.RemoveFromEvent(typeof(T), eventName);
}