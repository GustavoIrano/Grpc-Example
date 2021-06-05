using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }


        public override Task<ReturnId> ReturnGuid(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ReturnId
            {
                Guid = Guid.NewGuid().ToString()
            });
        }

        public override Task<HelloReply> ReturnNumberRangeMegaSena(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = new Random().Next(1, 60).ToString()
            });
        }
    }
}
