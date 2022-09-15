using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }

        public List<Folder> Folders { get; set; }

        public static object Identity { get; internal set; }
    }
}
