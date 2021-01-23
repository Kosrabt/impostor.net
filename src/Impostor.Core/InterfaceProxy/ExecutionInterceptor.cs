using Castle.DynamicProxy;
using Impostor.Core.Pipeline;
using System;
using System.Linq;

namespace Impostor.Core.InterfaceProxy
{
    public class ExecutionInterceptor : IInterceptor
    {
        private readonly IExecutionPipeline executionPipeline;

        public ExecutionInterceptor(IExecutionPipeline executionPipeline)
        {
            this.executionPipeline = executionPipeline;
        }

        public void Intercept(IInvocation invocation)
        {
            var request = new ExecutionRequest(invocation);
            var response = new ExecutionResponse(invocation);

            try
            {
                executionPipeline.Execute(request, response).Wait();
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions.FirstOrDefault() ?? ae;
            }

            invocation.ReturnValue = response.ReturnValue;
        }
    }
}
