using GearVeloAPI.CustomExceptionHandler.Abstracts;
using GearVeloAPI.DTOs;
using GearVeloAPI.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace GearVeloAPI.CustomExceptionHandler.Concretes;

public class ValidationExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var validationException = (ValidationException)exception;

        return new ExceptionResultDto(MediaTypeNames.Application.Json,
            (int)HttpStatusCode.BadRequest, 
            JsonSerializer.Serialize(validationException.Errors));
    }
}