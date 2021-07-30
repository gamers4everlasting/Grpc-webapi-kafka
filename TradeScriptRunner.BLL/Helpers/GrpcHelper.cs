using Grpc.Net.Client;

namespace TradeScriptRunner.BLL.Helpers
{
    public static class GrpcHelper
    {
        private static Alert.AlertClient _client;
        public static Alert.AlertClient GetOrCreateAlertClient(string serviceUrl)
        {
            if (_client != null) return _client;
            
            var channel = GrpcChannel.ForAddress(serviceUrl);
            _client = new Alert.AlertClient(channel);

            return _client;
        }
    }
}