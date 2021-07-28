namespace TradeScriptRunner.Common.Results
{
    public class ExecuteResult
    {
        public ExecuteState State { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool IsSuccess => State == ExecuteState.Success;

        public static ExecuteResult Success()
        {
            return new ExecuteResult { State = ExecuteState.Success };
        }

        public static ExecuteResult Success(string message)
        {
            return new ExecuteResult { State = ExecuteState.Success, Message = message };
        }

        public static ExecuteResult Error(string errorMessage)
        {
            return new ExecuteResult { State = ExecuteState.Error, Message = errorMessage };
        }
    }
}