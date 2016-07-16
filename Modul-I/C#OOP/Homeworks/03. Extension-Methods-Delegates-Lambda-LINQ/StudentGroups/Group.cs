namespace StudentGroups
{
    public class Group
    {
        public Group(int groupNumber, string departement)
        {
            this.GroupNumber = groupNumber;
            this.Departement = departement;
        }

        public int GroupNumber { get; private set; }

        public string Departement { get; private set; }
    }
}
