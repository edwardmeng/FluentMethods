using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and calls the adder of the given event with it
    /// </summary>
    /// <param name="il"></param>
    /// <param name="event">The event to add the delegate instance to</param>
    public static ILGenerator AddToEvent(this ILGenerator il, EventInfo @event)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (@event == null)
            throw new ArgumentNullException(nameof(@event));
        return il.Call(@event.GetAddMethod(true));
    }

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and call the adder of the event with the given
    ///     name on the given type
    /// </summary>
    /// <remarks>Will only consider public events, static or instance</remarks>
    /// <param name="il"></param>
    /// <param name="type">The type the event is on</param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator AddToEvent(this ILGenerator il, Type type, string eventName)
        => il.AddToEvent(GetEventInfo(type, eventName));

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and call the adder of the event with the given
    ///     name on the given type
    /// </summary>
    /// <remarks>Will only consider public events, static or instance</remarks>
    /// <param name="il"></param>
    /// <param name="type">The type the event is on</param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator AddToEvent(this ILGenerator il, TypeInfo type, string eventName) => il.AddToEvent(type?.AsType(), eventName);
#endif

    /// <summary>
    ///     Pops a reference to a delegate instance off the evaluation stack and call the adder of the event with the given
    ///     name on the given type
    /// </summary>
    /// <remarks>Will only consider public events, static or instance</remarks>
    /// <typeparam name="T">The type the event is on</typeparam>
    /// <param name="il"></param>
    /// <param name="eventName">The name of the event</param>
    public static ILGenerator AddToEvent<T>(this ILGenerator il, string eventName)
        => il.AddToEvent(typeof(T), eventName);

    private static EventInfo GetEventInfo(Type type, string eventName)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        var eventInfo = type.GetTypeInfo().GetEvent(eventName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
#else
        var eventInfo = type.GetEvent(eventName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
#endif
        if (eventInfo == null)
            throw new InvalidOperationException("There is no event called `" + eventName + "` on the type " + type.Name);
        return eventInfo;
    }
}