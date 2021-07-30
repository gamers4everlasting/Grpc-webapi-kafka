using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradeScriptRunner.BLL.Interfaces;
using TradeScriptRunner.Common.Results;
using TradeScriptRunner.DAL;

namespace TradeScriptRunner.BLL.Services
{
    public class AlertService : BaseService, IAlertService
    {
        private readonly ApplicationDbContext _context;

        public AlertService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TradeScriptRunner.DAL.Entities.Alert>> GetAlerts()
        {
            return await _context.Alerts.ToListAsync();
        }
        
        public async Task<ExecuteResult> CreateAlert(TradeScriptRunner.DAL.Entities.Alert value)
        {
            return await ExecuteAsync(async () =>
            {
                var anyInDb = await _context.Alerts.AnyAsync(x => x.Name == value.Name && x.Script == value.Script);
                if (anyInDb)
                    return new ExecuteResult
                    {
                        Message = "Alert already exists",
                        State = ExecuteState.Error
                    };

                _context.Alerts.Add(new TradeScriptRunner.DAL.Entities.Alert {Name = value.Name, Script = value.Script});
                await _context.SaveChangesAsync();

                return ExecuteResult.Success();
            });
        }
    }
}