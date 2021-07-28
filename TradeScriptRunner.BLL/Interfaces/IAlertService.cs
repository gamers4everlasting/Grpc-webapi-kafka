using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeScriptRunner.Common.Results;
using TradeScriptRunner.DAL.Entities;

namespace TradeScriptRunner.BLL.Interfaces
{
    public interface IAlertService
    {
        public Task<IEnumerable<Alert>> GetAlerts();
        public Task<ExecuteResult> CreateAlert(Alert value);
    }
}