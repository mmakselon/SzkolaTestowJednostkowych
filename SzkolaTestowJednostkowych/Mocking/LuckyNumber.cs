using System;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class LuckyNumber
    {
        private Random _random;
        private INumberRepository _numberRepository;
        private IDateTimeProvider _dateTimeProvider;
        private Action<string> _logAction;

        // Konstruktor umożliwiający wstrzykiwanie zależności
        public LuckyNumber(Random random = null, INumberRepository numberRepository = null, IDateTimeProvider dateTimeProvider = null, Action<string> logAction = null)
        {
            _random = random ?? new Random();
            _numberRepository = numberRepository ?? new NumberRepository();
            _dateTimeProvider = dateTimeProvider ?? new DateTimeProvider();
            _logAction = logAction ?? Console.WriteLine;  // Domyślne logowanie na konsolę
        }

        public int Generate()
        {
            var luckyNumber = _random.Next(100);

            _numberRepository.AddRandomNumber(luckyNumber, _dateTimeProvider.Now);

            _logAction($"Szczęśliwa liczba to: {luckyNumber}");

            return luckyNumber;
        }
    }

}
