using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Entity
{
    public class Note
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool FavoriteStatus { get; set; }
        public int NumberOfReadings { get; set; }

        public int NoteBookID { get; set; }
        public Notebook Notebook { get; set; }
      
    }
}