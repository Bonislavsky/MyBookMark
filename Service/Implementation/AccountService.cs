using Microsoft.EntityFrameworkCore;
using MyBookMarks.DAL.interfaces;
using MyBookMarks.DAL.Repositories;
using MyBookMarks.Domain.Helpers;
using MyBookMarks.Domain.Response;
using MyBookMarks.Domain.Enum;
using MyBookMarks.Models;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace MyBookMarks.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFolderRepository _folderRepository;
        private const int StartNumberOfFolders = 3;

        public AccountService(IUserRepository userRepository, IFolderRepository folderRepository)
        {
            _userRepository = userRepository;
            _folderRepository = folderRepository;
        }

        public Response<ClaimsIdentity> LoginUser(LoginViewModel model)
        {   
            User user = _userRepository.GetByEmail(model.Email);

            if (user == null)
            {
                return new Response<ClaimsIdentity>
                {
                    StatusCode = StatusCode.Warning,
                    Description = "Данний електронний адрес не зареестрованний на сайті" 
                };
            }

            if (HashPasswordSHA512.VerifyHash(model.Password ,user.Salt, user.Password))
            {
                var result = Authenticate(user);
                return new Response<ClaimsIdentity>
                {
                    StatusCode = StatusCode.Ok,
                    Description = "Аккаунт підтверджено",
                    Data = result
                };
            }

            return new Response<ClaimsIdentity>
            {
                StatusCode = StatusCode.Warning,
                Description = "Пароль не вірний"
            };
            
        }

        public Response<ClaimsIdentity> RegisterUser(RegistrViewModel model)
        {
            User user = _userRepository.GetByEmail(model.Email);

            if (user != null)
            {
                return new Response<ClaimsIdentity>
                {
                    StatusCode = StatusCode.Warning,
                    Description = "Данний електронний адрес вже зареестрованний на сайті"
                };
            }

            var TmpSalt = HashPasswordSHA512.CreateSalt();
            user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Salt = TmpSalt,
                Password = HashPasswordSHA512.HashPasswordSalt(model.Password, TmpSalt)
            };

            _userRepository.Add(user);
            CreateStartFolders(StartNumberOfFolders, user.Id);
            var result = Authenticate(user);            

            return new Response<ClaimsIdentity>
            {
                StatusCode = StatusCode.Ok,
                Description = "Аккаунт заареестрованно",
                Data = result
            };
        }

        private void CreateStartFolders(int quantity, long userId)
        {
            for (int i = 0; i < quantity; i++)
            {
                int numberFodler = _folderRepository.GetUserFolderList(userId).Count;
                _folderRepository.Add(new Folder
                {
                    Name = $"Папка №{numberFodler}",
                    UserId = userId,
                    BookMarks = new List<BookMark>()
                });
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
