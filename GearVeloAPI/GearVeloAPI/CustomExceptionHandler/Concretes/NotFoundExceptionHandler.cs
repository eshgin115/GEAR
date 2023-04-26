using GearVeloAPI.CustomExceptionHandler.Abstracts;
using GearVeloAPI.DTOs;
using GearVeloAPI.Exceptions;
using System.Net;
using System.Net.Mime;

namespace GearVeloAPI.CustomExceptionHandler.Concretes;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var notFoundException = (NotFoundException)exception;

        return new ExceptionResultDto(MediaTypeNames.Text.Plain,
            (int)HttpStatusCode.NotFound, notFoundException.Message);
    }
}