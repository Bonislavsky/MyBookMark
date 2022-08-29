using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class SettingProfileUserViewModel
    {
        public long UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }

        public Dictionary<string, int> f {get;set; }       //<NameFolder, CountBm>
    }
}
