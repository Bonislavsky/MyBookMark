using Microsoft.AspNetCore.Mvc;
using MyBookMarks.Service.Interfaces;
using MyBookMarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;

namespace MyBookMarks.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _ProfileService;

        public ProfileController(IProfileService profileService)
        {
            _ProfileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(long CurrentFodlerId = 0)
        {
            var userEmail = User.Identity.Name;
            var response = await _ProfileService.GetUser(userEmail);
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                ViewData["CurrentFolder"] = CurrentFodlerId;
                return View(response.Data);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddBookMark(AddBookMarkViewModel bookmark)
        {
            _ProfileService.AddBookMark(bookmark);
            return RedirectToAction("Profile", new { CurrentFodlerId = bookmark.CurrentFolderId });
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
            return RedirectToAction("Profile", new { CurrentFodlerId = folderId });
        }

        [HttpGet]
        public IActionResult DeleteBookMark(long bookMarkId, long currentFolderId)
        {
            _ProfileService.DeleteBookMark(bookMarkId);
            return RedirectToAction("Profile", new { CurrentFodlerId = currentFolderId });
        }
    }
}
