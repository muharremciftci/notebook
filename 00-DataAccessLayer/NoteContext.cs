using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_DataAccessLayer.Mapping;
using _00_Entity;

namespace _00_DataAccessLayer
{
    public class NoteContext:DbContext
    {
        public NoteContext():base("Note")
        {

        }

        internal DbSet<User> User { get; set; }
        internal DbSet<Notebook> Notebook { get; set; }
        internal DbSet<Note> Note { get; set; }
        internal DbSet<SharedNote> SharedNote { get; set; }
       
       


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteMap());
            modelBuilder.Configurations.Add(new NotebookMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SharedNoteMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
