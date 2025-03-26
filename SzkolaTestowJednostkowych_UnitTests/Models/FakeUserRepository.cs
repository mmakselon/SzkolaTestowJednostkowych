using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Mocking;

namespace SzkolaTestowJednostkowych_UnitTests.Models
{
    internal class FakeUserRepository : IUsersRepository
    {
        public bool Login(string user, string password)
        {
            if (user == "1" && password == "2")
            {
                return true;
            }
            else
            return false;
        }
    }
}
