using MyBookMarks.Domain.Response;
using MyBookMarks.Models;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookMarks.Domain.Enum;

namespace MyBookMarks.Service.Interfaces
{
    public interface IProfileService
    {
        Response<ProfileViewModel> GetUser(string userEmail);
        Folder GetFolder(long id);
        List<Folder> GetFolders(long id);
        List<BookMark> GetBookMarks(long folderId, SortType type = SortType.SortByDataCreate);

        void AddFolder(AddFolderViewModel folder);
        void DeleteFolder(long folderId);

        void AddBookMark(AddBmViewModel bookmark);
        void DeleteBookMark(long bookmarkId);
    }
}
