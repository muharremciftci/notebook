using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_Entity;

namespace _00_DataAccessLayer.Mapping
{
    public class NoteMap:EntityTypeConfiguration<Note>
    {
        public NoteMap()
        {
            HasKey(x => x.ID);
            Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title).HasMaxLength(500).HasColumnType("nvarchar");
            Property(x => x.Content).HasMaxLength(4000).HasColumnType("nvarchar");

            

            Property(x => x.NoteBookID).IsRequired();
            HasRequired(x => x.Notebook).WithMany().HasForeignKey(x => x.NoteBookID);




        }
    }
}
