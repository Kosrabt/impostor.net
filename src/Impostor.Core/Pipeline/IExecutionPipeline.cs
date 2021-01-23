using System.Threading.Tasks;

namespace Impostor.Core.Pipeline
{
    public interface IExecutionPipeline
    {
        Task Execute(IExecutionRequest request, IExecutionResponse response);
    }
}