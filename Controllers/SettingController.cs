using Microsoft.AspNetCore.Mvc;
using MyBookMarks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
