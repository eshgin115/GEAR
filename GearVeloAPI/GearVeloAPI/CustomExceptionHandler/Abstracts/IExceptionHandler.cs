using GearVeloAPI.DTOs;

namespace GearVeloAPI.CustomExceptionHandler.Abstracts;

public interface IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception);
}