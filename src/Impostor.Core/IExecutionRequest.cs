using System.Reflection;

namespace Impostor.Core
{
    public interface IExecutionRequest
    {
        MethodInfo InvocationMethodInfo { get; }
        object[] InvocationArguments { get; }
    }

    public interface IExecutionResponse
    {
        object ReturnValue { get; set; }
    }
}
