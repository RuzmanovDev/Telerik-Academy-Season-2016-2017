using System;

namespace Exceptions_Homework
{
    public class CSharpExam : Exam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;

        public CSharpExam(int score)
        {
            if (score < MinScore)
            {
                throw new ArgumentException($"The value score: {score} must be > 0!");
            }

            this.Score = score;
        }

        public int Score { get; private set; }

        public override ExamResult Check()
        {
            if (this.Score < MinScore || this.Score > MaxScore)
            {
                throw new ArgumentOutOfRangeException($"The value must be between {MinScore} and {MaxScore}!");
            }
            else
            {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score!");
            }
        }
    }
}