namespace Employees.Models
{
    public class Attendance
    {
        public static List<string> attendants = new List<string>();
        public static void AddAttendant(Person person)
        {
            person.InsertPerson();
        }
        
        public static List<Person> GetAttendants()
        {
            List<Person> person = Person.FetchAllPersons();
            return person;
        }
    }
}
