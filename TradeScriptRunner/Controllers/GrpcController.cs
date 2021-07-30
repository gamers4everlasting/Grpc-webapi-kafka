using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradeScriptRunner.BLL;
using TradeScriptRunner.BLL.Interfaces;

namespace TradeScriptRunner.Controllers
{
    public class GrpcController : BaseApiController
    {
        private readonly ILogger<GrpcController> _logger;
        private readonly IGrpcSenderService _grpcSenderService;

        public GrpcController(ILogger<GrpcController> logger, IGrpcSenderService grpcSenderService)
        {
            _logger = logger;
            _grpcSenderService = grpcSenderService;
        }

        [HttpPost]
        public async Task<ActionResult<AlertReply>> RunScript([FromQuery] string name, string symbol, string script) //TODO: move to a model.
        {
            _logger.LogInformation("Request received for Run script");

            var result = await _grpcSenderService.SendRequestAsync(name, symbol, script);

            return Ok(result.Message);
        }
    }
}