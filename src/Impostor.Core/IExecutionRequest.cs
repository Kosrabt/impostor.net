namespace Impostor.Core
{
    public interface IExecutionRequest
    {
    }

    public interface IExecutionResponse
    {
        object ReturnValue { get; set; }
    }
}
