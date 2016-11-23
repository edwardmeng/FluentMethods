using System.Reflection.Emit;

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
