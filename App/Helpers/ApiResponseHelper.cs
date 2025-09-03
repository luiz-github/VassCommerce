namespace Helpers.ApiResponseHelper;

public class ApiResponseHelper
{
    public ApiResponseHelper(int stat_code, string message, object? data = null)
    {
        Stat_code = stat_code;
        Message = message;
        Data = data;
    }
    public int Stat_code { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public static ApiResponseHelper Success(string message, object? data = null)
    {
        return new ApiResponseHelper(200, message, data);  // Código 200 para sucesso
    }

    public static ApiResponseHelper Error(int statusCode, string? message, object? data = null)
    {
        return new ApiResponseHelper(statusCode, message, data);
    }
}