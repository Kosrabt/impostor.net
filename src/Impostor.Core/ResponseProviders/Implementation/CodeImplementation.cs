using Impostor.Core.Helpers;
using Impostor.Core.Pipeline;
using System.Threading.Tasks;

namespace Impostor.Core.ResponseProviders.Implementation
{
    public class CodeImplementation : IExecutionStep
    {
        private readonly object instance;

        public CodeImplementation(object instance)
        {
            this.instance = instance;
        }

        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            var method = request.InvocationMethodInfo;
            
            var implementationMethod = TypeHelper.GetMatchingMethod(instance.GetType(), method);
            if (implementationMethod == null)
            {
                await next(request, response);
            }
            else
            {
                response.ReturnValue = implementationMethod.Invoke(instance, request.InvocationArguments);
            }
        }
    }
}
