using Grpc.Net.Client;
using GrpcService.Server;

namespace TradeScriptRunner.BLL.Helpers
{
    public static class GrpcHelper
    {
        private static Greeter.GreeterClient _client;
        public static Greeter.GreeterClient GetOrCreateGreeterClient(string serviceUrl)
        {
            if (_client != null) return _client;
            
            var channel = GrpcChannel.ForAddress(serviceUrl);
            _client = new Greeter.GreeterClient(channel);

            return _client;
        }
    }
}