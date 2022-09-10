using MyBookMarks.DAL.interfaces;
using MyBookMarks.Domain.Enum;
using MyBookMarks.Domain.Response;
using MyBookMarks.Models;
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

            userProfile.Folders = _folderRepository.GetUserFolderList(userProfile.UserId);

            return new Response<SettingProfileUserViewModel>
            {
                Data = userProfile,
                Description = "всі данні знайденні",
                StatusCode = StatusCode.Ok
            };
        }

        public Response<User> ChangeUserdata(SettingProfileUserViewModel model)
        {
            var response = new Response<User>();

            try
            {
                User userData = _userRepository.Get(model.UserId);
                userData.Email = model.UserEmail;
                userData.Name = model.UserName;
                _userRepository.Update(userData);

                foreach (var folder in model.Folders)
                {
                    try
                    {
                        Folder folderData = _folderRepository.Get(folder.Id);
                        folderData.Name = folder.Name;
                        _folderRepository.Update(folderData);
                    }
                    catch (Exception)
                    {
                        response.Description = $"<внутрішня помилка> не вдалося оновити дані папок";
                        response.StatusCode = StatusCode.ServerError;
                        return response;
                    }
                }
                userData.Folders = model.Folders;

                response.Description = "дані успішно обновленні";
                response.StatusCode = StatusCode.Ok;
                response.Data = userData;
                return response;
            }
            catch (Exception)
            {
                response.Description = $"<внутрішня помилка> не вдалося оновити дані";
                response.StatusCode = StatusCode.ServerError;

                return response;
            }
        }
    }
}
