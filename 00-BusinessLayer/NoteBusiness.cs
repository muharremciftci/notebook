using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_DataAccessLayer;
using _00_Entity;

namespace _00_BusinessLayer
{
    public class NoteBusiness
    {
        UnitOfWork db;
        public NoteBusiness()
        {
            db = new UnitOfWork();
        }
        public bool Add(Note note)
        {
            db.NoteRepository.Add(note);
            return db.ApplyChanges();
        }
        public bool Update(Note note)
        {
            db.NoteRepository.Update(note);
            return db.ApplyChanges();
        }
        public bool Delete(int id)
        {
            Note note = db.NoteRepository.Get(id);
            db.NoteRepository.Delete(note);
            return db.ApplyChanges();
        }
        //Notlarımın hepsinin gelmesi için yazıldı
        public List<Note> GetMyNote(int id)
        {
           return (from note in db.NoteRepository.GetAll()
                   join notebook in db.NotebookRepository.GetAll() on note.NoteBookID equals notebook.ID
                   where notebook.UserID==id
                   select note
                   ).ToList();
        }
        public List<Note> GetByNotebook(int notebookID)
        {
            return db.NoteRepository.GetAll().Where(x=>x.NoteBookID==notebookID).ToList();
        }
        public Note Get(int id)
        {
            return db.NoteRepository.Get(id);
        }
        public bool NoteShare(Note note , int UserID)
        {
            SharedNote sharedNote = new SharedNote();
            sharedNote.NoteID = note.ID;
            sharedNote.UserID = UserID;
            db.SharedNoteRepository.Add(sharedNote);
            return db.ApplyChanges();

        }
    }
}
