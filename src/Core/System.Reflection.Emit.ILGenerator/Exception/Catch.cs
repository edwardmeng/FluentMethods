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

    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType, Action filter) => il.Catch(exceptionType, x => filter?.Invoke());

    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType) => il.Catch(exceptionType, (Action<ILGenerator>)null);

    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action<ILGenerator> filter) where T : Exception => il.Catch(typeof(T), filter);

    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action filter) where T : Exception => il.Catch(typeof(T), filter);

    public static ILGeneratorScope Catch<T>(this ILGenerator il) where T : Exception => il.Catch<T>((Action<ILGenerator>)null);

    public static ILGeneratorScope Catch(this ILGenerator il, Action<ILGenerator> filter) => il.Catch((Type)null, filter);

    public static ILGeneratorScope Catch(this ILGenerator il, Action filter) => il.Catch((Type)null, filter);

    public static ILGeneratorScope Catch(this ILGenerator il) => il.Catch((Action<ILGenerator>)null);

#if Net45 || NetCore
    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType) => il.Catch(exceptionType?.AsType());

    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType, Action filter) => il.Catch(exceptionType?.AsType(), filter);

    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType, Action<ILGenerator> filter) => il.Catch(exceptionType?.AsType(), filter);
#endif
}