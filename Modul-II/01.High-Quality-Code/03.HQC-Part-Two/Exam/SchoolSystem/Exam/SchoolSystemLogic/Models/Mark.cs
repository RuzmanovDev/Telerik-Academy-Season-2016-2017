using System;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Models
{
    public class Mark : IMark
    {
        private float markValue;
        private SubjectType subjectType;

        public Mark(SubjectType subjectType, float markValue)
        {
            this.subjectType = subjectType;
            this.MarkValue = markValue;
        }

        public float MarkValue
        {
            get
            {
                return this.markValue;
            }

            private set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("The value of he mark must be betwenn 1 and 12");
                }

                this.markValue = value;
            }
        }

        public SubjectType SubjectType
        {
            get
            {
                return this.subjectType;
            }
        }
    }
}
