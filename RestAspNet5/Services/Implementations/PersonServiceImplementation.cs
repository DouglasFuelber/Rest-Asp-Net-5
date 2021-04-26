using RestAspNet5.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestAspNet5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
                people.Add(MockPerson(i));

            return people;
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Douglas",
                LastName = "Fuelber",
                Address = "Brazil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Name " + i,
                LastName = "LastName " + i,
                Address = "Person Address",
                Gender = (i % 2 == 0) ? "Male" : "Female"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
