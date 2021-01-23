using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Impostor.Core.Pipeline
{

    public class ExecutionPipeline : IExecutionPipeline
    {
        private readonly ExecutionStepDelegate executionStepDelegate;

        public ExecutionPipeline(IEnumerable<IExecutionStep> steps)
        {
            executionStepDelegate = BuildPipeline(steps);
        }

        public async Task Execute(IExecutionRequest request, IExecutionResponse response)
        {        
            await executionStepDelegate.Invoke(request, response).ConfigureAwait(false);
        }

        private static ExecutionStepDelegate BuildPipeline(IEnumerable<IExecutionStep> steps)
        {
            ExecutionStepDelegate pipeline = (request, response) => Task.CompletedTask;

            foreach (var s in steps.Reverse())
            {
                pipeline = WrapStep(s, pipeline);
            }

            return pipeline;
        }

        private static ExecutionStepDelegate WrapStep(IExecutionStep step, ExecutionStepDelegate next) => (rq, rs) => step.Execute(rq, rs, next);
    }
}
