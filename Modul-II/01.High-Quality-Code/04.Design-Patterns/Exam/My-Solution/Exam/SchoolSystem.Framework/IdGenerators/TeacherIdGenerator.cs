namespace SchoolSystem.Framework.IdGenerators
{
    public class TeacherIdGenerator : IIdGenerator
    {
        private int id;

        public TeacherIdGenerator()
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
