using GearVeloAPI.CustomExceptionHandler.Abstracts;
using GearVeloAPI.DTOs;
using GearVeloAPI.Exceptions;
using System.Net;
using System.Net.Mime;

namespace GearVeloAPI.CustomExceptionHandler.Concretes;

public class BadRequestExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var badRequestException = (BadRequestException)exception;

        return new ExceptionResultDto(MediaTypeNames.Text.Plain,
            (int)HttpStatusCode.BadRequest, badRequestException.Message);
    }
}
