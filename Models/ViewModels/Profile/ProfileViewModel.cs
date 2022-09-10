using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels
{
    public class ProfileViewModel
    {
        public long UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }

        public List<Folder> Folders { get; set; }
    }
}
