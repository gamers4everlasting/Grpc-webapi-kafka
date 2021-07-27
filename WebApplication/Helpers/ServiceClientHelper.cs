using System;
using System.Net;
using System.Net.Http;
using Grpc.Net.Client;
using GrpcService.Server;

namespace WebApplication.Helpers
{
    public class ServiceClientHelper
    {
        private static Greeter.GreeterClient _client;
        public static Greeter.GreeterClient GetGreeterClient(string serviceUrl)
        {
            if (_client == null)
            {
                // var channel = GrpcChannel.ForAddress(serviceUrl, new GrpcChannelOptions
                // {
                //     HttpClient = client
                // });
                var channel = GrpcChannel.ForAddress(serviceUrl);
                _client = new Greeter.GreeterClient(channel);
            }

            return _client;
        }
    }
}