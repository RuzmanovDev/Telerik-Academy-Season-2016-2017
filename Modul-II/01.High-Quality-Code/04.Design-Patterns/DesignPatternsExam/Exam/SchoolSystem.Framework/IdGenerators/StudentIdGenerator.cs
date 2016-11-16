namespace SchoolSystem.Framework.IdGenerators
{
    public class StudentIdGenerator : IIdGenerator
    {
        private int id;

        public StudentIdGenerator()
        {
            this.id = 0;
        }

        public int GetId
        {
            get
            {
                return this.id++;
            }
        }
    }
}
