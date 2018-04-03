using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00_DataAccessLayer.Repository;

namespace _00_DataAccessLayer
{
    public class UnitOfWork
    {
        NoteContext _context;
        public UnitOfWork()
        {
            _context = new NoteContext();
        }

        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
        private NoteRepository _noteRepository;

        public NoteRepository NoteRepository
        {
            get
            {
                if (_noteRepository == null)
                {
                    _noteRepository = new NoteRepository(_context);
                }
                return _noteRepository;
            }
        }
        private NotebookRepository _notebookRepository;

        public NotebookRepository NotebookRepository
        {
            get
            {
                if (_notebookRepository == null)
                {
                    _notebookRepository = new NotebookRepository(_context);
                }
                return _notebookRepository;
            }
        }

        private SharedNoteRepository _sharedNoteRepository;

        public SharedNoteRepository SharedNoteRepository
        {
            get
            {
                if (_sharedNoteRepository == null)
                {
                    _sharedNoteRepository = new SharedNoteRepository(_context);
                }
                return _sharedNoteRepository;
            }
        }













        public bool ApplyChanges()
        {
            bool isSuccess = false;
            DbContextTransaction _tran;
            _tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                _context.SaveChanges();
                _tran.Commit();
                isSuccess = true;
            }
            catch (Exception)
            {
                _tran.Rollback();
                isSuccess = false;
            }
            finally
            {
                _tran.Dispose();
            }
            return isSuccess;
        }
    }
}
