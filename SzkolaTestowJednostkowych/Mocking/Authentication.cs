using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolaTestowJednostkowych.Mocking
{
    public class Authentication
    {
        private readonly IUsersRepository _usersRepository;

        public Authentication(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public string Login(string user, string password)
        {
            var isAuthenticated = _usersRepository.Login(user, password);

            if (!isAuthenticated)
                return "User or password is incorrect.";

            return string.Empty;
        }
    }

}
