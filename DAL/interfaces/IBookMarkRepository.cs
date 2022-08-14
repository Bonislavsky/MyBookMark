using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.interfaces
{
    public interface IBookMarkRepository : IRepository<BookMark>
    {
        List<BookMark> GetFolderBookMarkList(long folderId);
        void DeletedBookMarkList(long folderId);
    }
}
