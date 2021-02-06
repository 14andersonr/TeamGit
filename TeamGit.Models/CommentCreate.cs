using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGit.Models
{
   public class CommentCreate
    {
        [Required]
        public string Text { get; set; }
    }
}

