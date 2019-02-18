using RestWithASPNET.Data.Converter;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converters
{
    public class UserConverter 
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return null;
            return new User
            {
                Login = origin.Login,
                AcessKey = origin.AcessKey
            };
        }
        public UserVO Parse(User origin)
        {
            if (origin == null) return null;
            return new UserVO
            {
                Login = origin.Login,
                AcessKey = origin.AcessKey
            };
        }
    }
}
