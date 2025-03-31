using System;

namespace SzkolaTestowJednostkowych.Mocking
{

    public class LuckyNumber
    {
        private Random _random;
        private INumberRepository _numberRepository;

        public LuckyNumber(Random random = null, INumberRepository numberRepository = null)
        {
            _random = random ?? new Random();
            _numberRepository = numberRepository ?? new NumberRepository();
        }

        public int Generate()
        {
            var luckyNumber = _random.Next(100);

            _numberRepository.AddRandomNumber(luckyNumber, DateTime.Now);

            Console.WriteLine($"Szczęśliwa liczba to: {luckyNumber}");

            return luckyNumber;
        }
    }
}
