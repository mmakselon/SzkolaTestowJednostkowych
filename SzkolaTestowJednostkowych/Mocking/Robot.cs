using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class Robot
    {
        public string Greetings()
        {
            if (DateTime.Now.Hour < 18)
                return "Dzień dobry!";

            return "Dobry wieczór!";
        }
    }
}
