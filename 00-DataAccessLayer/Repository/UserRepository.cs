using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_Entity;

namespace _00_DataAccessLayer.Repository
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository(NoteContext context):base(context)
        {
                
        }
    }
}
