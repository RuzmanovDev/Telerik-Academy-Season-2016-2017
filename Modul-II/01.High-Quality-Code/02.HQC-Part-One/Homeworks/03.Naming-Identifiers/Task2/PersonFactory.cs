namespace Task2
{
    public class PersonFactory
    {
        public Person CreatePerson(int personTypeId)
        {
            var person = this.ConfigurePerson(personTypeId);

            return person;
        }

        private Person ConfigurePerson(int creatingPersonIdentifier)
        {
            var person = new Person();
            person.Age = creatingPersonIdentifier;

            if (creatingPersonIdentifier % 2 == 0)
            {
                person.Name = "Pesho";
                person.Gender = GenderType.Male;
            }
            else
            {
                person.Name = "Mariika";
                person.Gender = GenderType.Female;
            }

            return person;
        }
    }
}
