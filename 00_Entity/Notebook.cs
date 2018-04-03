using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Entity
{
   public  class Notebook
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
