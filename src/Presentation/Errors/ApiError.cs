namespace tech_test_payment_api.Presentation.Errors;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ApiError
{
    public ApiError(string message, string innerMessage)
    {
        this.Message = message;
        this.InnerMessage = innerMessage;
    }

    public string Message { get; set; }
    public string InnerMessage { get; set; }
}

