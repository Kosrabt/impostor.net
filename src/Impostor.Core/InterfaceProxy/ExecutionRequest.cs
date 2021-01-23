using Castle.DynamicProxy;

namespace Impostor.Core.InterfaceProxy
{
    internal class ExecutionRequest: IExecutionRequest
    {
        private IInvocation invocation;

        public ExecutionRequest(IInvocation invocation)
        {
            this.invocation = invocation;
        }
    }
}