using System.Collections.Generic;

namespace Console_ToDo_Uygulaması
{
    public class PersonList
    {
        public static List<Person> persons = new();

        public PersonList()
        {
            persons.Add(new Person("1", "Furkan Elmas"));
            persons.Add(new Person("2", "Anıl Kara"));
            persons.Add(new Person("3", "Kerem Kırmızıdemir"));
        }
    }
}