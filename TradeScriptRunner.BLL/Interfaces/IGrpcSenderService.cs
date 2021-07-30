using System.Threading.Tasks;

namespace TradeScriptRunner.BLL.Interfaces
{
    public interface IGrpcSenderService
    {
        public Task<AlertReply> SendRequestAsync(string name, string symbol, string script);
    }
}