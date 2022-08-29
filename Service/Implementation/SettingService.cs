using MyBookMarks.DAL.interfaces;
using MyBookMarks.Domain.Response;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;
using MyBookMarks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Service.Implementation
{
    public class SettingService : ISettingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookMarkRepository _bookMarkRepository;
        private readonly IFolderRepository _folderRepository;

        public SettingService(IUserRepository userRepository, IBookMarkRepository bookMarkRepository,
            IFolderRepository folderRepository)
        {
            _userRepository = userRepository;
            _bookMarkRepository = bookMarkRepository;
            _folderRepository = folderRepository;
        }

        public Response<SettingProfileUserViewModel> GetUserSetting(string userEmail)
        {
            var userProfile = _userRepository.GetAll()
                .Select(u => new SettingProfileUserViewModel
                {
                    UserEmail = u.Email,
                    UserId = u.Id,
                    UserName = u.Name,
                }).FirstOrDefault(x => x.UserEmail == userEmail);

            var folderUser = _folderRepository.GetUserFolderList(userProfile.UserId);

            return null;
        }
    }
}
