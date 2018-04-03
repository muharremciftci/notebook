using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_Entity;

namespace _00_DataAccessLayer.Mapping
{
    public class SharedNoteMap:EntityTypeConfiguration<SharedNote>
    {
        public SharedNoteMap()
        {
            HasKey(x => new { x.NoteID, x.UserID });

       
            HasRequired(x => x.Note).WithMany().HasForeignKey(x => x.NoteID).WillCascadeOnDelete(false);

            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserID).WillCascadeOnDelete(false);
        }
    }
}
