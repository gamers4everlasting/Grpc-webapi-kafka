using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.Common.Results;
using WebApplication.DAL.Entities;

namespace WebApplication.BLL.Interfaces
{
    public interface IAlertService
    {
        public Task<IEnumerable<Alert>> GetAlerts();
        public Task<ExecuteResult> CreateAlert(Alert value);
    }
}