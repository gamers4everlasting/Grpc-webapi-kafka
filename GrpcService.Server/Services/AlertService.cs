using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Modulus.TradeScript.Alerts;
using Modulus.TradeScript.Engine;
using Modulus.TradeScript.Engine.Syntax.Expressions;
using Modulus.TradeScript.Globalization;
using TradeScriptRunner.BLL;

namespace GrpcService.Server.Services
{
    public class AlertService : TradeScriptRunner.BLL.Alert.AlertBase
    {
        private readonly ILogger<AlertService> _logger;
        private static readonly NumberFormatInfo _decimalFormatProvider = new()
        {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ".",
            NumberGroupSizes = new int[] { 2 }
        };
        private static readonly ScriptExecutor _scriptExecutor = new(new Localizer());

        public AlertService(ILogger<AlertService> logger)
        {
            _logger = logger;
        }

        public override Task<AlertReply> ExecuteAlert(AlertRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Request received in Alert server: {request.Name}");
            var sb = new StringBuilder();
            var alert = new Modulus.TradeScript.Alerts.Alert(request.Name, request.Symbol, request.Script);
            var unit = new AlertNotificationUnit(alert, _scriptExecutor);
            
            unit.Alert += (s, e) =>
            {
                var print = $"[ALERT] {e.Alert}";
                sb.AppendLine(print);
            };
            unit.Error += (s, e) =>
            {
                var error = $"[{e.Alert.Name}:ERROR] {e.Description}";
                sb.AppendLine(error);
                if (e.Exception != null)
                {
                    if (e.Exception is FunctionExpressionException fde)
                    {
                        var sourceException = fde.InnerException!;
                        sb.AppendLine($"Source error message: {sourceException!.Message}");
                        sb.AppendLine($"Details:\n{fde.Details}");
                        sb.AppendLine($"Source exception:\n{sourceException}");
                    }
                    else
                    {
                        sb.AppendLine(e.Exception.ToString());
                    }
                }
            };
            
            _logger.LogInformation(sb.ToString());
            
            var dataSet = LoadData();
            unit.Run(dataSet);
            
            return Task.FromResult(new AlertReply()
            {
                Message = sb.ToString()
            });
            
        }
        
        
        private static List<Ohlc> LoadData()
        {
            var list = new List<Ohlc>();
            var lines = File.ReadAllLines(@"Bac.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] r = lines[i].Split(',');
                if (r.Length > 5)
                {
                    var timestamp = DateTimeOffset.Parse(r[0]);
                    var open = Convert.ToDouble(r[1], _decimalFormatProvider);
                    var high = Convert.ToDouble(r[2], _decimalFormatProvider);
                    var low = Convert.ToDouble(r[3], _decimalFormatProvider);
                    var close = Convert.ToDouble(r[4], _decimalFormatProvider);
                    var volume = Convert.ToInt64(r[5]);

                    var ohlc = new Ohlc
                    {
                        Timestamp = timestamp,
                        Open = open,
                        High = high,
                        Low = low,
                        Close = close,
                        Volume = volume
                    };

                    list.Add(ohlc);
                }
            }
            return list;
        }
    }
}