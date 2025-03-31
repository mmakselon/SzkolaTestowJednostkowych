using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    // Implementacja repository
    public class NumberRepository : INumberRepository
    {
        public void AddRandomNumber(int number, DateTime date)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Numbers.Add(new RandomNumber
                {
                    Number = number,
                    Date = date
                });
                context.SaveChanges(); // Zapis do bazy danych
            }
        }
    }
}
