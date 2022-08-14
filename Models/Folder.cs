using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models
{
    public class Folder
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long UserId { get; set; }

        public List<BookMark> BookMarks { get; set; }
    }
}
