using System.Reflection.Emit;

/// <summary>
/// The wrapper of the <see cref="ILGenerator"/> for the branch clauses of the IL emitting.
/// </summary>
public sealed class BranchILGenerator
{
    internal BranchILGenerator(ILGenerator il, Label label, bool shortForm)
    {
        IL = il;
        Label = label;
        ShortForm = shortForm;
    }

    internal ILGenerator IL { get; }

    internal Label Label { get; }

    internal bool ShortForm { get; }
}
