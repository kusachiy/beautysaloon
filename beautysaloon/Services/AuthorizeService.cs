using beautysaloon.Models.RequestResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Services
{ 
    class AuthorizeService
    {
        private UserService _userService;
        private RoleService _roleService;

        public AuthorizeService()
        {
            _userService = new UserService();
            _roleService = new RoleService();
        }
        public AuthorizeResponse Authorize(Credentalis credentalis)
        {
            var users = _userService.GetAll();
            var roles = _roleService.GetAll();

            var userByLogin = users.FirstOrDefault(u => u.Login == credentalis.Login);
            if (userByLogin != null)
                if (userByLogin.HashPassword == credentalis.PasswordHash)
                {
                    var role = roles.FirstOrDefault(f => f.Id == userByLogin.RoleID);
                    if (role != null)
                        userByLogin.Role = role;
                    return new AuthorizeResponse() { CurrentUser = userByLogin, Found = true, Status = "Пользователь найден" };
                }
            return new AuthorizeResponse() { CurrentUser = null, Found = false, Status = "Некорретные входные данные" };

        }      
        
    }
}
