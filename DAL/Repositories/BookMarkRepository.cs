using Microsoft.EntityFrameworkCore;
using MyBookMarks.DAL.interfaces;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.DAL.Repositories
{
    public class BookMarkRepository : IBookMarkRepository
    {
        private readonly MyBookMarksDbContext _Dbase;

        public BookMarkRepository(MyBookMarksDbContext ctx)
        {
            _Dbase = ctx;
        }

        public void Add(BookMark bookMark)
        {
            try
            {
                _Dbase.BookMarks.Add(bookMark);
                _Dbase.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Delete(long bookMarkId)
        {
            _Dbase.BookMarks.Remove(Get(bookMarkId));
            _Dbase.SaveChanges();
        }

        public BookMark Get(long bookMarkId)
        {
            return _Dbase.BookMarks
                    .Where(u => u.Id == bookMarkId)
                    .First();
        }

        public void Update(BookMark bookMark)
        {
            _Dbase.BookMarks.Update(bookMark);
            _Dbase.SaveChanges();
        }

        public IQueryable<BookMark> GetAll()
        {
            return _Dbase.BookMarks;
        }

        public List<BookMark> GetFolderBookMarkList(long folderId)
        {
            return _Dbase.BookMarks
                    .Where(folder => folder.FolderId == folderId)
                    .ToList();
        }

        public void DeletedBookMarkList(long folderId)
        {
            var removeBookmark = GetFolderBookMarkList(folderId);
            _Dbase.BookMarks.RemoveRange(removeBookmark);
            _Dbase.SaveChanges();
        }
    }
}
