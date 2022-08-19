using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookMarks.Models.ViewModels.Profile
{
    public class DeletedBmViewModel
    {
        public long BookMarkId { get; set; }
        public long CurrentFolderId { get; set; }
    }
}
