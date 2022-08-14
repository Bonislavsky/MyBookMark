using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.interfaces
{
    public interface IFolderRepository : IRepository<Folder>
    {
        Task<List<Folder>> GetUserFolderList(long userId);
    }
}
