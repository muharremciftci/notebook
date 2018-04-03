using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Entity
{
   public class SharedNote
    {
        public int NoteID { get; set; }
        public virtual Note Note { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }

    }
}
