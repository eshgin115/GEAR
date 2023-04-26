using GearVeloAPI.CustomExceptionHandler.Abstracts;
using GearVeloAPI.DTOs;

namespace GearVeloAPI.CustomExceptionHandler.Concretes;
public class ExceptionHandlerService
{
    private readonly Dictionary<Type, Func<IExceptionHandler>> _exceptionHandlers;

    public ExceptionHandlerService()
    {
        _exceptionHandlers = new Dictionary<Type, Func<IExceptionHandler>>();
    }

    public void RegisterHandler<T>(Func<IExceptionHandler> handler)
        where T : ApplicationException
    {
        ArgumentNullException.ThrowIfNull(handler);

        _exceptionHandlers[typeof(T)] = handler;
    }

    public ExceptionResultDto Handle(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);

        return _exceptionHandlers[exception.GetType()].Invoke().Handle(exception);
    }
}
