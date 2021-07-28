using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TradeScriptRunner.DAL;
using TradeScriptRunner.DAL.Entities;

namespace TradeScriptRunner.Controllers
{
    [Route("api/[controller]")]
    public class SimpleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SimpleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Alert> Get()
        {
            return _context.Alerts.ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alert value)
        {
            _context.Alerts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }
    }
}