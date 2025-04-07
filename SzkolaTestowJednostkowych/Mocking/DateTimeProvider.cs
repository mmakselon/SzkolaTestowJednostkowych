using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
    }

}
