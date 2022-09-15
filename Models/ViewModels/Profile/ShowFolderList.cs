using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class ShowFolderList
    {
        public List<Folder> Folders { get; set; }
        public long UserId { get; set; }
    }
}
