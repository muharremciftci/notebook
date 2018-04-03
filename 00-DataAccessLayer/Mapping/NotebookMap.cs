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
    public class NotebookMap:EntityTypeConfiguration<Notebook>
    {
        public NotebookMap()
        {
            HasKey(x => x.ID);
            Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title).HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.UserID).IsRequired();
            HasRequired(x => x.User).WithMany().HasForeignKey(x => x.UserID);
        }
    }
}
