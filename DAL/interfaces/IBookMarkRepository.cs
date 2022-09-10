using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.interfaces
{
    public interface IBookMarkRepository : IRepository<BookMark>
    {
        List<BookMark> GetBookMarkList(long folderId);
        void DeleteAllUserBookmark(long folderId);
    }
}
