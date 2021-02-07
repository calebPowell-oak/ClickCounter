using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickCounter.Services.Interfaces
{
    public interface IQuizService
    {
        public string GenerateQuiz();
        public bool ValidateQuiz(string answer);
    }
}
