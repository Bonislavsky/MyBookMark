using MyBookMarks.Domain.Response;
using MyBookMarks.Models.ViewModels;
using MyBookMarks.Models.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Service.Interfaces
{
    public interface ISettingService
    {
        Response<SettingProfileUserViewModel> GetUserSetting(string userEmail);
    }
}
