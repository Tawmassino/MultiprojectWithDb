using Microsoft.EntityFrameworkCore;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.DBRepositories
{
    public class NotesDBRepository : INotesDBRepository
    {
        private readonly MultiprojectDbContext _context;

        public NotesDBRepository(MultiprojectDbContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        // ==================== methods ====================
        public int AddNewNote(Note newNote)
        {
            _context.Notes.Add(newNote);
            _context.SaveChanges();
            return newNote.Id;

        }

        public void DeleteNote(int id)
        {
            var noteToDelete = _context.Notes.Find(id);
            _context.Notes.Remove(noteToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAllNotesByUser(int id)
        {
            return _context.Notes.Include(n => n.User).Where(note => note.Id == id);
        }

        public Note GetNoteById(int id)
        {
            return _context.Notes.Include(n => n.User).FirstOrDefault(n => n.Id == id);
        }

        public Note GetNoteByTitle(string title)
        {
            return _context.Notes.Include(n => n.User).FirstOrDefault(n => n.Title == title);
        }

        public void UpdateNote(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }
    }
}
