using RestAspNet5.Model;
using RestAspNet5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAspNet5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context) {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Person.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Person.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Person.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            Person personDb = _context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (personDb != null) {
                try
                {
                    _context.Entry(personDb).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            Person personDb = _context.Person.SingleOrDefault(p => p.Id.Equals(id));

            if (personDb != null)
            {
                try
                {
                    _context.Person.Remove(personDb);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }
    }
}
