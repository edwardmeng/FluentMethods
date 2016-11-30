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
            if (exceptionType == null)
            {
                filter(il);
                il.BeginCatchBlock(null);
            }
            else
            {
                var exceptionLocal = il.DeclareLocal(exceptionType);
                Label endFilter = il.DefineLabel(), rightType = il.DefineLabel();
                il
                    .Isinst(exceptionType).Dup()
                    .BranchShortTo(rightType).IfTrue()
                    .Pop().Ldc(false)
                    .BranchTo(endFilter).Unconditionally();
                il.MarkLabel(rightType);
                il.StoreLocal(exceptionLocal);
                il.LoadLocal(exceptionLocal);
                filter(il);
                il.MarkLabel(endFilter);
                il.BeginCatchBlock(null);
                il.Pop().LoadLocal(exceptionLocal);
            }
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