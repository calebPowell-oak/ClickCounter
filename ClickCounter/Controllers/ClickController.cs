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
        private ISessionService _SessionService;

        public ClickController(ICountService CountService,
            ISessionService SessionService)
        {
            _CountService = CountService;
            _SessionService = SessionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(440)]
        public ActionResult<int> CountUp()
        {
            try
            {
                if (_SessionService.CheckIfSessionValid(new Guid(Request.Headers["Session-Guid"])))
                {
                    return Ok(_CountService.CountUp());
                }
                return BadRequest("Session not valid");

            } catch (System.ArgumentNullException)
            {
                return BadRequest("Missing request header: Session-Guid");
            }
            catch (System.SystemException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public int Count()
        {
            return _CountService.GetCurrentCount();
        }
    }
}
