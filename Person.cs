namespace Console_ToDo_Uygulaması
{
    public class Person
    {
        private string _personalID;
        private string _nameSurname;

        public string PersonalID { get => _personalID; set => _personalID = value; }
        public string Name { get => _nameSurname; set => _nameSurname = value; }

        public Person(string personalID, string nameSurname)
        {
            PersonalID = personalID;
            Name = nameSurname;
        }
    }
}