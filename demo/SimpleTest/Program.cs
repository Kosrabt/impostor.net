using Impostor.Core;
using Impostor.Core.Pipeline;
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
             new Dummy1(),
             new Dummy2(),
             new Dummy3()
            };

            new ExecutionPipeline(steps).Execute(null).GetAwaiter().GetResult();
        }
        
    }

    class Dummy1 : IExecutionStep
    {
        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            Console.WriteLine(this.GetType().FullName + " starting");
            await next(request, response);
            Console.WriteLine(this.GetType().FullName + " finishing");
        }
    }

    class Dummy2 : IExecutionStep
    {
        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            Console.WriteLine(this.GetType().FullName + " starting");
            await next(request, response);
            Console.WriteLine(this.GetType().FullName + " finishing");
        }
    }

    class Dummy3 : IExecutionStep
    {
        public async Task Execute(IExecutionRequest request, IExecutionResponse response, ExecutionStepDelegate next)
        {
            Console.WriteLine(this.GetType().FullName + " starting");
            await next(request, response);
            Console.WriteLine(this.GetType().FullName + " finishing");
        }
    }
}
