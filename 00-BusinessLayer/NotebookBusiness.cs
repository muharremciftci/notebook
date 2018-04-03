using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_DataAccessLayer;
using _00_Entity;

namespace _00_BusinessLayer
{
   public class NotebookBusiness
    {
        UnitOfWork db;
        public NotebookBusiness()
        {
            db = new UnitOfWork();
        }
        public bool Add(Notebook notebook)
        {
            db.NotebookRepository.Add(notebook);
            return db.ApplyChanges();
        }
        public bool Update(Notebook notebook)
        {
            db.NotebookRepository.Update(notebook);
            return db.ApplyChanges();
        }
        public bool Delete(Notebook notebook)
        {
            db.NotebookRepository.Delete(notebook);
            return db.ApplyChanges();
        }
     public Notebook Get(int id)
        {
            return db.NotebookRepository.Get(id);
        }
        public List<Notebook> GetMyNotebook(int id)
        {
            List<Notebook> notebooks= db.NotebookRepository.GetAll().Where(x => x.UserID == id).ToList();
            return notebooks;
        }

    }
}
