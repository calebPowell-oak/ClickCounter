using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickCounter.Services.Interfaces;

namespace ClickCounter.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClickController : ControllerBase
    {

        private ICountService _CountService;

        public ClickController(ICountService CountService)
        {
            _CountService = CountService;
        }

        [HttpGet]
        public int CountUp()
        {
            return _CountService.CountUp();
        }

        [HttpGet]
        public int Count()
        {
            return _CountService.GetCurrentCount();
        }
    }
}
