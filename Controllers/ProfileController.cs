using Microsoft.AspNetCore.Mvc;
using MyBookMarks.Service.Interfaces;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using MyBookMarks.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace MyBookMarks.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _ProfileService;

        public ProfileController(IProfileService profileService)
        {
            _ProfileService = profileService;
        }

        [HttpGet]      
        public IActionResult Profile()
        {
            var userEmail = User.Identity.Name;
            var response = _ProfileService.GetUser(userEmail);
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult ViewFolder(long folderId)
        {
            var result = _ProfileService.GetFolder(folderId);
            result.BookMarks = _ProfileService.GetBookMarks(folderId);
            return PartialView("_ShowBookMarkPatrial", result);
        }

        [HttpPost]
        public IActionResult AddBookMark(AddBmViewModel bookmark)
        {
            if (Uri.IsWellFormedUriString(bookmark.Url, UriKind.Absolute))
            {
                _ProfileService.AddBookMark(bookmark);
                return RedirectToAction("ViewFolder", new { folderId = bookmark.CurrentFolderId });
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        public IActionResult AddFolder(AddFolderViewModel model)
        {
            _ProfileService.AddFolder(model);
            var result = _ProfileService.GetFolders(model.UserId);
            return PartialView("_ShowListFolderPartial", new ShowFolderList() { Folders = result, UserId = model.UserId });
        }

        [HttpPost]
        public PartialViewResult DeleteFolder(long userId, long folderId)
        {
            _ProfileService.DeleteFolder(folderId);
            var result = _ProfileService.GetFolders(userId);
            return PartialView("_ShowListFolderPartial", new ShowFolderList(){ Folders = result, UserId = userId });
        }

        [HttpPost]
        public IActionResult DeleteBookMark(long bookmarkId, long folderId)
        {
            _ProfileService.DeleteBookMark(bookmarkId);
            return RedirectToAction("ViewFolder", new { folderId = folderId });
        }

        [HttpPost]
        public IActionResult SortBookmarks(SortBmViewModel sortmodel)
        {
            var result = _ProfileService.GetFolder(sortmodel.FolderId);
            result.BookMarks = _ProfileService.GetBookMarks(sortmodel.FolderId, sortmodel.SortType);
            return PartialView("_ShowBookMarkPatrial", result);
        }
    }
}
