using System.Threading.Tasks;

namespace Impostor.Core.Pipeline
{
    public delegate Task ExecutionStepDelegate(IExecutionRequest request, IExecutionResponse response);

    public interface IExecutionStep
    {
        Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next);
    }
}
