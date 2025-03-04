using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class LuckyNumber
    {
        private Random _random = new Random();
        
        public int Generate()
        {
            var luckyNumber = _random.Next(100);

            using (var context = new ApplicationDbContext())
            {
                context.Numbers.Add(
                    new RandomNumber 
                    {
                        Number = luckyNumber, 
                        Date = DateTime.UtcNow
                    });
            }

            Console.WriteLine($"Szczęśliwa liczba to: {luckyNumber}");

            return luckyNumber;
        }
    }
}
