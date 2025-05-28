using System.Text.Json;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Exceptions;

namespace TreeStructure.API.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SecureException secureEx)
        {
            await HandleSecureExceptionAsync(context, secureEx);
        }
        catch (Exception generalEx)
        {
            await HandleGeneralExceptionAsync(context, generalEx);
        }
    }

    private async Task HandleSecureExceptionAsync(HttpContext context, SecureException ex)
    {
        var journalService = context.RequestServices.GetRequiredService<IJournalService>();
        var journal = await journalService.CreateAsync(ex, ex.Parameters);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            type = ex.GetType().Name,
            id = journal.EventId,
            data = new { message = ex.Message }
        };

        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }

    private async Task HandleGeneralExceptionAsync(HttpContext context, Exception ex)
    {
        var journalService = context.RequestServices.GetRequiredService<IJournalService>();
        var journal = await journalService.CreateAsync(ex, null);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            type = ex.GetType().Name,
            id = journal.EventId,
            data = new { message = $"Internal server error ID = {journal.EventId}" }
        };

        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}