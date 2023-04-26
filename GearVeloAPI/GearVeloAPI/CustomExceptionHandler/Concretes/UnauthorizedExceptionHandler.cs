using GearVeloAPI.CustomExceptionHandler.Abstracts;
using GearVeloAPI.DTOs;
using GearVeloAPI.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace GearVeloAPI.CustomExceptionHandler.Concretes;

public class UnauthorizedExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(Exception exception)
    {
        var unauthorizedException = (UnauthorizedException)exception;

        return new ExceptionResultDto
            (MediaTypeNames.Application.Json,
            (int)HttpStatusCode.Unauthorized, 
            JsonSerializer.Serialize(unauthorizedException.Message));
    }
}