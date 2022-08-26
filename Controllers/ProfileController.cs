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
        public async Task<IActionResult> Profile()
        {
            var userEmail = User.Identity.Name;
            var response = await _ProfileService.GetUser(userEmail);
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
            return PartialView("_ShowFolderPatrial", result);
        }

        [HttpPost]
        public IActionResult AddBookMark(AddBmViewModel bookmark)
        {
            _ProfileService.AddBookMark(bookmark);
            return RedirectToAction("ViewFolder", new { folderId = bookmark.CurrentFolderId });
        }

        [HttpPost]
        public IActionResult AddFolder(AddFolderViewModel folder)
        {
            _ProfileService.AddFolder(folder);
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult DeleteFolder(long folderId)
        {
            _ProfileService.DeleteFolder(folderId);
            return RedirectToAction("Profile");
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
            return PartialView("_ShowFolderPatrial", result);
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View(); // comit
        }
    }
}
