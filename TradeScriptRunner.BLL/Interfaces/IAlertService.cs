using System.Collections.Generic;
using System.Threading.Tasks;
using TradeScriptRunner.Common.Results;

namespace TradeScriptRunner.BLL.Interfaces
{
    public interface IAlertService
    {
        public Task<IEnumerable<TradeScriptRunner.DAL.Entities.Alert>> GetAlerts();
        public Task<ExecuteResult> CreateAlert(TradeScriptRunner.DAL.Entities.Alert value);
    }
}