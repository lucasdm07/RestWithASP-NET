using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.User.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}
