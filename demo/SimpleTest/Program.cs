using Impostor.Core;
using Impostor.Core.InterfaceProxy;
using Impostor.Core.Pipeline;
using Impostor.Core.ResponseProviders.Implementation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var steps = new List<IExecutionStep>()
            {
                new LoggingExecutionStep(),
                new CodeImplementation(new PartialImplementationOfTheInterface()),
                new DefaultAnswerExecutionStep()
            };

            //THis all will be hidden by DI
            var pipeline = new ExecutionPipeline(steps);
            var interceptor = new ExecutionInterceptor(pipeline);

            var interfaceProxy = new InterfaceProxyFactory(interceptor);

            var mockedInterface = (IInterfaceToMock)interfaceProxy.CreateProxy(typeof(IInterfaceToMock));

            //THis will be given by the Instumentation. Like MVC
            var result = mockedInterface.Calculate(10,20);

            Console.WriteLine($"mockedInterface.Calculate(10,20) result is: {result}");

            Console.WriteLine();
            Console.WriteLine();
            var result2 = mockedInterface.Half(10);

            Console.WriteLine($"mockedInterface.Half(10,20) result is: {result2}");
        }        
    }

    public interface IInterfaceToMock
    {
        int Calculate(int a, int b);

        int Half(int a);
    }

    class PartialImplementationOfTheInterface
    {
        public int Calculate(int a, int b)
        {
            Console.WriteLine("PartialImplementation is called!");
            Console.WriteLine($"Called with a: {a} and b: {b} ");

            return 1000;
        }
    }    


    class LoggingExecutionStep : IExecutionStep
    {
        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            Console.WriteLine("Logging: Something Starting");
            await next(request, response);
            Console.WriteLine("Logging: Something Finished");
        }
    }

    class DefaultAnswerExecutionStep : IExecutionStep
    {
        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            Console.WriteLine("Default Implementation is called!");

            response.ReturnValue = 100;
        }
    }
}
