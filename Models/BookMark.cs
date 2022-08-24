using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models
{
    public class BookMark
    {
        public int Id { get; set; }

        public DateTime DateСreation { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public long FolderId { get; set; }
    }
}
