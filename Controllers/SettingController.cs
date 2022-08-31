using Microsoft.AspNetCore.Mvc;
using MyBookMarks.Service.Interfaces;
using MyBookMarks.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyBookMarks.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _SettingService;

        public SettingController(ISettingService settingService)
        {
            _SettingService = settingService;
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var userEmail = User.Identity.Name;
            var response = _SettingService.GetUserSetting(userEmail);
            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Settings(SettingProfileUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                var response = _SettingService.ChangeUserdata(model);
                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return Json(new
                    {
                        description = response.Description,
                        statusCode = "Ok"
                    });
                }
                else if(response.StatusCode == Domain.Enum.StatusCode.ServerError)
                {
                    return Json(new
                    {
                        description = response.Description,
                        statusCode = "error"
                    });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
