using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType, Action<ILGenerator> filter)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (filter == null)
        {
            il.BeginCatchBlock(exceptionType ?? typeof(object));
        }
        else
        {
            il.BeginExceptFilterBlock();
            var exceptionLocal = il.DeclareLocal<object>();
            il.ConvertTo<object>().StoreLocal(exceptionLocal);
            if (exceptionType == null)
            {
                il.LoadLocal(exceptionLocal);
                filter(il);
            }
            else
            {
                // emit filter block. Filter blocks are untyped so we need to do
                // the type check ourselves.  
                Label endFilter = il.DefineLabel(), rightType = il.DefineLabel();
                var filterLocal = il.DeclareLocal<bool>();
                // skip if it's not our exception type, but save
                // the exception if it is so it's available to the
                // filter
                il.LoadLocal(exceptionLocal).IsInstanceOf(exceptionType)
                    .BranchShortTo(rightType).IfTrue()
                    .StoreLocal(filterLocal, false)
                    .BranchTo(endFilter).Unconditionally();
                il.MarkLabel(rightType);
                il.LoadLocal(exceptionLocal);
                filter(il);
                il.StoreLocal(filterLocal);
                il.MarkLabel(endFilter);
                il.LoadLocal(filterLocal);
            }
            il.BeginCatchBlock(null);
            il.LoadLocal(exceptionLocal);
        }
        return new ILGeneratorScope(il);
    }

    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType, Action filter)
    {
        return il.Catch(exceptionType, x => filter?.Invoke());
    }

    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType)
    {
        return il.Catch(exceptionType, (Action<ILGenerator>)null);
    }

    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action<ILGenerator> filter) where T : Exception
    {
        return il.Catch(typeof(T), filter);
    }

    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action filter) where T : Exception
    {
        return il.Catch(typeof(T), filter);
    }

    public static ILGeneratorScope Catch<T>(this ILGenerator il) where T : Exception
    {
        return il.Catch<T>((Action<ILGenerator>)null);
    }

    public static ILGeneratorScope Catch(this ILGenerator il, Action<ILGenerator> filter)
    {
        return il.Catch(null, filter);
    }

    public static ILGeneratorScope Catch(this ILGenerator il, Action filter)
    {
        return il.Catch(null, filter);
    }

    public static ILGeneratorScope Catch(this ILGenerator il)
    {
        return il.Catch((Action<ILGenerator>)null);
    }
}