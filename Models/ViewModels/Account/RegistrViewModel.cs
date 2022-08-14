using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBookMarks.Models.ViewModels
{
    public class RegistrViewModel
    {
        [Required(ErrorMessage = "Вкажіть електрону пошту")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректна адреса")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Вкажіть пароль")]
        [RegularExpression(@"[0-9a-zA-Z]{6,20}", ErrorMessage = "пароля може містити тільки латинські літери або цифри")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Підтвердіть пароль")]
        [Compare("Password", ErrorMessage = "паролі не збігаются")]
        public string PasswordConfirme { get; set; }

        [Required(ErrorMessage = "Вкажіть Ім'я")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "довжина повинна бути від 2 до 25 символів")]
        public string Name { get; set; }
    }
}
