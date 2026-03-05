using System;

namespace AppProject.Exceptions;

public class AppException : Exception
{
    public AppException(
        ExceptionCode exceptionCode = ExceptionCode.Generic,
        string? addtionalInfo = null,
        Exception? innerException = null)
        : base(innerException?.Message, innerException)
    {
        this.ExceptionCode = exceptionCode;
        this.AdditionalInfo = addtionalInfo;
    }

    public ExceptionCode ExceptionCode { get; }

    public string? AdditionalInfo { get; }
}
