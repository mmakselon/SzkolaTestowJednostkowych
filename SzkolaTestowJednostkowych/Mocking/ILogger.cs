using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public interface ILogger
    {
        void Error(Exception exception, string message);
    }
}
