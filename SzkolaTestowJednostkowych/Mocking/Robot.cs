using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class Robot
    {
        private IClock _clock;

        public Robot(IClock clock)
        {
            _clock = clock;
        }

        public string Greetings()
        {
            if (_clock.GetCurrentHour() < 18)
                return "Dzień dobry!";

            return "Dobry wieczór!";
        }
    }
}
