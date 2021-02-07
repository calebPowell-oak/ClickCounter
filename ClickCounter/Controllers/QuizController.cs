using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickCounter.Services.Interfaces;

namespace ClickCounter.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private IQuizService _QuizService;
        private ISessionService _SessionService;

        public QuizController(IQuizService QuizService,
            ISessionService SessionService)
        {
            _QuizService = QuizService;
            _SessionService = SessionService;
        }

        [HttpGet]
        [ActionName("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Quiz()
        {
            return Ok(_QuizService.GenerateQuiz());
        }

        [HttpGet]
        [ActionName("submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Quiz([FromQuery] string answer)
        {
            if (_QuizService.ValidateQuiz(answer))
            {
                return Ok(_SessionService.CreateSession());
            } else
            {
                return BadRequest("Quiz Failed. Format: 'word,xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'");
            }
        }
    }
}
