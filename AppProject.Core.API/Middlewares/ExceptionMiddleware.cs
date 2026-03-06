using System;
using System.Net;
using System.Text.Json;
using AppProject.Exceptions;

namespace AppProject.Core.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionMiddleware> logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await this.next(context);
        }
        catch (AppException appException)
        {
            this.logger.LogError(appException.ToString());

            switch (appException.ExceptionCode)
            {
                case ExceptionCode.SecurityValidation:
                    await this.HandleExceptionAsync(context, appException.ExceptionCode, httpStatusCode: HttpStatusCode.Unauthorized);
                    return;
                case ExceptionCode.RequestValidation:
                    await this.HandleExceptionAsync(context, appException.ExceptionCode, appException.AdditionalInfo, httpStatusCode: HttpStatusCode.BadRequest);
                    return;
            }

            await this.HandleExceptionAsync(context, appException.ExceptionCode, appException.AdditionalInfo);
        }
        catch (Exception othertExecption)
        {
            this.logger.LogError(othertExecption.ToString());
            await this.HandleExceptionAsync(context);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ExceptionCode exceptionCode = ExceptionCode.Generic, string? additionalInfo = null, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(new ExceptionDetail()
            {
                ExceptionCode = exceptionCode,
                AditionalInfo = additionalInfo
            }));
    }
}
