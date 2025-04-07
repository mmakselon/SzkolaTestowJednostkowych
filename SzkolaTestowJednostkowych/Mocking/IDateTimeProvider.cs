using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }

}
