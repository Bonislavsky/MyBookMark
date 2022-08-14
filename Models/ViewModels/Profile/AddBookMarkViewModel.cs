using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels
{
    public class AddBookMarkViewModel 
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public long CurrentFolderId { get; set; }
    }
}
