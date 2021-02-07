using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickCounter.Services.Interfaces;

namespace ClickCounter.Services
{
    public class QuizService : IQuizService
    {
        private string[] QuizWords = {"California", "everything", "aboveboard", "Washington", "basketball", "weathering", "characters", "literature", "perfection", "volleyball", "depression", "homecoming", "technology", "maleficent", "watermelon", "appreciate", "relaxation", "convection", "abominable", "government", "salmonella", "strawberry", "aberration", "retirement", "television", "contraband", "Alzheimers", "silhouette", "friendship", "punishment", "loneliness", "university", "Cinderella", "confidence", "restaurant", "abstinence", "blancmange", "blackboard", "discipline", "renovation", "helicopter", "generation", "adaptation", "skateboard", "lightboard", "Apocalypse", "understand", "leadership", "revolution", "Antarctica"};
        private List<string> QuizAnswers = new List<string>();

        public string GenerateQuiz()
        {
            Random random = new Random();
            string randomWord;

            randomWord = QuizWords[random.Next(0, QuizWords.Length)];

            // Blank random letter of word
            char[] quizWord = randomWord.ToCharArray();
            quizWord[random.Next(0, quizWord.Length)] = '_';

            string guid = Guid.NewGuid().ToString();

            QuizAnswers.Add(randomWord + "," + guid);

            return new string(quizWord + "," + guid);
        }

        public bool ValidateQuiz(string answer)
        {
            return QuizAnswers.Remove(answer);
        }
    }
}
