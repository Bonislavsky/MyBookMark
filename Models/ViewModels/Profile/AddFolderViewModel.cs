using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class AddFolderViewModel
    {
        [StringLength(20)]
        public string Name { get; set; }
        public long UserId { get; set; }
    }
}
