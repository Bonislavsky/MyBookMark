using MyBookMarks.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class SortBmViewModel
    {
        public long FolderId { get; set; }     
        public SortType SortType { get; set; } 
    }
}
