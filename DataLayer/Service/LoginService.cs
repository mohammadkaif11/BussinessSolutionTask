using BussinessLayer;
using BussinessLayer.Reposistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Service
{
    public class LoginService : ILoginService
    {
        //Login service
        private readonly IResposistoryBase<User> userRepo;
        public LoginService(IResposistoryBase<User> _userRepo)
        {
            this.userRepo = _userRepo;
        }
        public User Login(string username, string password)
        {
            var user = new User();
            user = userRepo.Login(username, password);
            if (user == null) { return null; }
            else return user;
        }
    }
}
