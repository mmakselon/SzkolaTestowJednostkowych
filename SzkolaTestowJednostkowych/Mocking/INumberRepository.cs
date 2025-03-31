using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public interface INumberRepository
    {
        void AddRandomNumber(int number, DateTime date);
    }
}
