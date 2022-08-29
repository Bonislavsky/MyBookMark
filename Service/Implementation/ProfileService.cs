using MyBookMarks.DAL.interfaces;
using MyBookMarks.DAL.Repositories;
using MyBookMarks.Domain.Response;
using Microsoft.EntityFrameworkCore;
using MyBookMarks.Models;
using MyBookMarks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MyBookMarks.Domain.Enum;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;

namespace MyBookMarks.Service.Implementation
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBookMarkRepository _bookMarkRepository;
        private readonly IFolderRepository _folderRepository;

        public ProfileService(IUserRepository userRepository, IBookMarkRepository bookMarkRepository,
            IFolderRepository folderRepository)
        {
            _userRepository = userRepository;
            _bookMarkRepository = bookMarkRepository;
            _folderRepository = folderRepository;
        }

        public void AddFolder(AddFolderViewModel folder)
        {
            _folderRepository.Add(
                new Folder 
                {
                    Name = folder.Name ?? "Папка", 
                    UserId = folder.UserId 
                });
        }

        public void DeleteFolder(long folderId)
        {
            _bookMarkRepository.DeletedBookMarkList(folderId);
            _folderRepository.Delete(folderId);
        }

        public Response<ProfileViewModel> GetUser(string userEmail)
        {
            var userProfile = _userRepository.GetAll()
                .Select(u => new ProfileViewModel
                {
                    UserEmail = u.Email,
                    UserId = u.Id,
                    UserName = u.Name,
                    Folders = u.Folders
                }).FirstOrDefault(x => x.UserEmail == userEmail);

            userProfile.Folders = _folderRepository.GetUserFolderList(userProfile.UserId);

            return new Response<ProfileViewModel>
            {
                Data = userProfile,
                Description = "всі данні знайденні",
                StatusCode = StatusCode.Ok
            };
        }

        public Folder GetFolder(long id)
        {
            return _folderRepository.Get(id);
        }

        public List<BookMark> GetBookMarks(long folderId, SortType type = SortType.SortByDataCreate)
        {
            var bookMarkList = _bookMarkRepository.GetFolderBookMarkList(folderId);
            switch (type)
            {
                case SortType.SortByDataCreate:
                    bookMarkList.Sort((x, y) => x.DateСreation.CompareTo(y.DateСreation));
                    break;
                case SortType.SortByName:
                    bookMarkList.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
                case SortType.SortByUrl:
                    bookMarkList.Sort((x, y) => x.Url.CompareTo(y.Url));
                    break;
            }
            return bookMarkList;
        }

        public void AddBookMark(AddBmViewModel bookmark)
        {
           _bookMarkRepository.Add(
                new BookMark()
                {
                    DateСreation = DateTime.UtcNow,
                    Name = bookmark.Name?? bookmark.Url,
                    Url = bookmark.Url,
                    FolderId = bookmark.CurrentFolderId
                });        
        }

        public void DeleteBookMark(long bookmarkId)
        {
            _bookMarkRepository.Delete(bookmarkId);
        }
    }
}
