using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class SettingProfileUserViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Вкажіть електрону пошту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректна адреса")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Вкажіть Ім'я")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "довжина повинна бути від 2 до 25 символів")]
        public string UserName { get; set; }

        public List<Folder> Folders { get; set; } 
    }
}
