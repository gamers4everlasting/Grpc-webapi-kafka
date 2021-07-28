using System.Threading.Tasks;
using GrpcService.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TradeScriptRunner.BLL.Helpers;

namespace TradeScriptRunner.Controllers
{
    public class GrpcController : BaseApiController
    {
        private readonly ILogger<GrpcController> _logger;
        private readonly IConfiguration _config;
        private readonly Greeter.GreeterClient _greeterClient;

        public GrpcController(IConfiguration config, ILogger<GrpcController> logger)
        {
            _config = config;
            _logger = logger;
            _greeterClient = GrpcHelper.GetOrCreateGreeterClient(_config["RPCService:ServiceUrl"]);
        }

        [HttpPost]
        public  ActionResult<HelloReply> RunScript([FromQuery] string name)
        {
            _logger.LogInformation("Request received for Run script");
            var result = _greeterClient.SayHello(new HelloRequest
            {
                Name = name
            });

            return Ok(result.Message);
        }
    }
}