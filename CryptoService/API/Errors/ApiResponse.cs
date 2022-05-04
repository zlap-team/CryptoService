namespace API.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch // variable SWITCH
        {
            400 => "Bad Request", // variable value => returned value
            401 => "Not Authorized",
            404 => "Not Found",
            500 => "Server Error",
            _ => null
        };
    }
}