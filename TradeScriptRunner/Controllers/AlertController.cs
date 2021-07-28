using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeScriptRunner.BLL.Interfaces;
using TradeScriptRunner.DAL.Entities;

namespace TradeScriptRunner.Controllers
{
    public class AlertController : BaseApiController
    {
        private readonly IAlertService _alertService;

        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Alert>))]
        public IActionResult Get()
        {
            return Ok(_alertService.GetAlerts());
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(Alert alert)
        {
            var result = await _alertService.CreateAlert(alert);
            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequestError(result.Message);
        }
    }
}