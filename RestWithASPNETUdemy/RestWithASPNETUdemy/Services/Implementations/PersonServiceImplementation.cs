using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> GetAll()
        {
            return new List<Person>()
            {
                new Person() {
                    Id = 1,
                    Address = "Natal",
                    FirstName = "Hanna",
                    LastName = "Cruz",
                    Gender = "Female" },
                new Person() {
                    Id = 2,
                    Address = "Natal",
                    FirstName = "Denilson",
                    LastName = "Silva",
                    Gender = "Male" },
                new Person() {
                    Id = 3,
                    Address = "Natal",
                    FirstName = "Pedro",
                    LastName = "Borges",
                    Gender = "Male" }
            };
        }

        public Person GetById(long id)
        {
            return new Person
            {
                Id = id,
                Address = "Natal",
                FirstName = "Denilson",
                LastName = "Silva",
                Gender = "Male" 
                
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
