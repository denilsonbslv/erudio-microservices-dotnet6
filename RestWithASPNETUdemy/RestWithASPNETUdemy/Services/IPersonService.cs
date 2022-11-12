using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person GetById(long id);

        List<Person> GetAll();

        Person Update(Person person);

        void Delete(long id);

    }
}
