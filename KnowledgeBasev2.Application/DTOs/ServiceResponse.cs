namespace KnowledgeBasev2.Application.DTOs
{
    public record ServiceResponse(bool Error, string Message);
    public record ServiceResponse<T>(bool Error, string Message, T Data);
}
