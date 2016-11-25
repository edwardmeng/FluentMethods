using System;
using System.Reflection.Emit;

public sealed class ILGeneratorScope : IDisposable
{
    private ILGenerator _il;
    private Action _disposeAction;

    internal ILGeneratorScope(ILGenerator il, Action disposeAction = null)
    {
        _il = il;
        _disposeAction = disposeAction;
    }

    void IDisposable.Dispose()
    {
        if (_il == null) throw new ObjectDisposedException("ILGeneratorScope");
        _disposeAction?.Invoke();
        _il = null;
        _disposeAction = null;
    }
}
