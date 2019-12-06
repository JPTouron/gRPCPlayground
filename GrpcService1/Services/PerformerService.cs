using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcService1.Services
{
    public class PerformerService : Performer.PerformerBase
    {
        private readonly ILogger<GreeterService> _logger;

        public PerformerService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<PerformReply> PerformIt(PerformRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PerformReply
            {
                Age = 19,
                Name = request.Name
            });
        }
    }
}