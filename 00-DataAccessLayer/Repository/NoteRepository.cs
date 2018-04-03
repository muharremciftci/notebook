using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_Entity;

namespace _00_DataAccessLayer.Repository
{
   public class NoteRepository:BaseRepository<Note>
    {
        public NoteRepository(NoteContext context):base(context)
        {
                
        }
    }
}
