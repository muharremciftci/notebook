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
   public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(x => x.ID);
            Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FullName).HasMaxLength(100).HasColumnType("nvarchar");
            Property(x => x.Password).HasMaxLength(50).HasColumnType("nvarchar");
            Property(x => x.Email).HasMaxLength(50).HasColumnType("nvarchar");



        }
    }
}
