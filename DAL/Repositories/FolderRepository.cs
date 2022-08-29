using Microsoft.EntityFrameworkCore;
using MyBookMarks.DAL.interfaces;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly MyBookMarksDbContext _Dbase;

        public FolderRepository(MyBookMarksDbContext ctx)
        {
            _Dbase = ctx;
        }

        public void Add(Folder folder)
        {
            try
            {
                _Dbase.Folders.Add(folder);
                _Dbase.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void Delete(long folderId)
        {
            _Dbase.Folders.Remove(Get(folderId));
            _Dbase.SaveChanges();
        }

        public Folder Get(long folderId)
        {
            return _Dbase.Folders
                .FirstOrDefault(u => u.Id == folderId);
        }

        public IQueryable<Folder> GetAll()
        {
            return _Dbase.Folders;
        }

        public List<Folder> GetBookMarks(long userId)
        {
            return _Dbase.Folders
                .Include(Folder => Folder.UserId == userId)
                .ToList();
        }

        public List<Folder> GetUserFolderList(long userId)
        {
            return _Dbase.Folders
                .Where(folder => folder.UserId == userId)
                .ToList();
        }

        public void Update(Folder folder)
        {
            _Dbase.Folders.Update(folder);
            _Dbase.SaveChanges();
        }
    }
}
