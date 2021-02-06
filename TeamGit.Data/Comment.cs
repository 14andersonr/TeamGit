using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGit.Data
{

    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
       
        public Guid Auther { get; set; }

        //[ForeignKey](nameof)(Post))]
        public int PostId { get; set; }
        //public virtual Post   { get; set; }
        //public virtual List<Reply> Reply { get; set; }
    }
}

