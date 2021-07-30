using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TradeScriptRunner.BLL.Helpers;
using TradeScriptRunner.BLL.Interfaces;

namespace TradeScriptRunner.BLL.Services
{
    public class GrpcSenderService : IGrpcSenderService
    {
        private readonly Alert.AlertClient _alertClient;
        private readonly ILogger<GrpcSenderService> _logger;

        public GrpcSenderService(ILogger<GrpcSenderService> logger, IConfiguration config)
        {
            _logger = logger;
            _alertClient = GrpcHelper.GetOrCreateAlertClient(config["RPCService:ServiceUrl"]);
        }

        public Task<AlertReply> SendRequestAsync(string name, string symbol, string script)
        {
            var response = _alertClient.ExecuteAlert(new AlertRequest
            {
                Name = name,
                Symbol = symbol,
                Script = script
            });
            _logger.LogInformation($"Received data: {response.Message} from grpc server");

            return Task.FromResult(response);
        }
    }
}