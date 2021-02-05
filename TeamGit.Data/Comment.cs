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
        public string Text { get; set; }
       // [ForeignKey(Auther)]/UserId
        public Guid Auther { get; set; }

        //(virtual list of Replies)
      //(Foreign Key to Post via Id w/ virtual Post) 
//Reply(either as a separate class, or inherited from Comment - your choice)






    }
}
