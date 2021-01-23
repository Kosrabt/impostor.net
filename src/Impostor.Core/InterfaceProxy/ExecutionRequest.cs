using Castle.DynamicProxy;
using System.Reflection;

namespace Impostor.Core.InterfaceProxy
{
    internal class ExecutionRequest: IExecutionRequest
    {
        private readonly IInvocation invocation;
        public MethodInfo InvocationMethodInfo => invocation.Method;

        public object[] InvocationArguments => invocation.Arguments;

        public ExecutionRequest(IInvocation invocation)
        {
            this.invocation = invocation;
        }
    }
}