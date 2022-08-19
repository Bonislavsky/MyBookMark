using MyBookMarks.Domain.Response;
using MyBookMarks.Models;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Service.Interfaces
{
    public interface IProfileService
    {
        Task<Response<ProfileViewModel>> GetUser(string UserEmail);
        Folder GetFolder(long id);
        List<BookMark> GetBookMarks(long folderId);

        void AddFolder(AddFolderViewModel folder);
        void DeleteFolder(long folderId);

        void AddBookMark(AddBmViewModel bookmark);
        void DeleteBookMark(long bookmarkId);
    }
}
