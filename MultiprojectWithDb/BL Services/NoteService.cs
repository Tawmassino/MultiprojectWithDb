using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;

namespace MultiprojectWithDB.BusinessLogic.Services
{
    public class NoteService : INoteService
    {
        private readonly INotesDBRepository _notesDBRepository;

        public NoteService(INotesDBRepository notesDBRepository)
        {
            _notesDBRepository = notesDBRepository;
        }

        // ==================== methods ====================
        public NoteResponse AddNewNote(Note note)
        {
            var existingNote = _notesDBRepository.GetNoteByTitle(note.Title);
            if (existingNote != null)
            {
                return new NoteResponse(false, "Note already exists");
            }

            _notesDBRepository.AddNewNote(note);
            return new NoteResponse(true);

        }

        public Note GetNote(string noteTitle)
        {
            return _notesDBRepository.GetNoteByTitle(noteTitle);
        }

        public Note GetNoteById(int id)
        {
            return _notesDBRepository.GetNoteById(id);
        }

        public List<Note> GetUserNotes(int userId)
        {
            return _notesDBRepository.GetAllNotesByUser(userId).ToList();
        }

        public void RemoveNote(int noteId)
        {
            _notesDBRepository.DeleteNote(noteId);
        }

        public void UpdateNote(Note note, int userId)
        {
            //kai yra tarpinis servisas, gali but pamestas dbcontext

            var noteFromDB = _notesDBRepository.GetNoteById(note.Id);
            if (noteFromDB == null)
            {
                throw new Exception("Shopping list not found");//ilogger
            }
            if (noteFromDB.UserId != userId)
            {
                throw new Exception("User is trying to update foreign note");
            }

            _notesDBRepository.UpdateNote(note);
        }
    }
}
