using Castle.DynamicProxy;

namespace Impostor.Core.InterfaceProxy
{
    internal class ExecutionResponse: IExecutionResponse
    {
        private IInvocation invocation;

        public object ReturnValue { get; set; }

        public ExecutionResponse(IInvocation invocation)
        {
            this.invocation = invocation;
        }
    }
}