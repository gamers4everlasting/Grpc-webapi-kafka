using System;
using System.Threading.Tasks;
using TradeScriptRunner.Common.Results;

namespace TradeScriptRunner.BLL.Services
{
    public class BaseService
    {
        protected ExecuteResult Execute(Func<ExecuteResult> func, string errorDescription = "")
        {
            try
            {
                return func();
            }
            catch (Exception exp)
            {
                return ExecuteResult.Error(errorDescription + exp.Message);
            }
        }
        
        protected async Task<ExecuteResult> ExecuteAsync (Func<Task<ExecuteResult>> func, string errorDescription = "")
        {
            try
            {
                return await func();
            }
            catch (Exception exp)
            {
                return ExecuteResult.Error(errorDescription + exp.Message);
            }
        }
    }
}