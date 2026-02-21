using System.Diagnostics;
using System.Text.Json;
using CRUD.Domain;
using CRUD.Commons;

public class ResponseWrapperMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseWrapperMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        var originalBodyStream = context.Response.Body;

        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        stopwatch.Stop();

        responseBody.Seek(0, SeekOrigin.Begin);
        var bodyText = await new StreamReader(responseBody).ReadToEndAsync();

        object? data = null;

        if (!string.IsNullOrWhiteSpace(bodyText))
        {
            try
            {                
                data = JsonSerializer.Deserialize<object?>(bodyText);
            }
            catch
            {
                data = bodyText;
            }
        }

        var apiResponse = new ApiResponse<object>
        {
            Success = context.Response.StatusCode < 400,
            Message = context.Response.StatusCode < 400 ? "Request successful" : "Request failed",
            Timestamp = DateTime.UtcNow,
            ProcessingTimeMs = stopwatch.ElapsedMilliseconds,
            Data = data
        };

        context.Response.Body = originalBodyStream;
        context.Response.ContentType = "application/json";

        var json = JsonSerializer.Serialize(apiResponse,
            new JsonSerializerOptions 
            { 
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

        await context.Response.WriteAsync(json);

        Logger.GetInstance().LogResponse($"[ResponseWrapperMiddleware] Wrapped response in ApiResponse. Success={apiResponse.Success}, StatusCode={context.Response.StatusCode}, ProcessingTimeMs={apiResponse.ProcessingTimeMs}", json); 
    }
}