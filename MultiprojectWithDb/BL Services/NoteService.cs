using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.DBInterfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public NoteResponseDTO AddNewNote(Note note)
        {
            var existingNote = _notesDBRepository.GetByTitle(note.Title);
            if (existingNote != null)
            {
                return new NoteResponseDTO(false, "Note already exists");
            }

            _notesDBRepository.AddNewNote(note);
            return new NoteResponseDTO(true);

        }

        public Note GetNote(string noteTitle)
        {
            return _notesDBRepository.GetByTitle(noteTitle);
        }

        public void RemoveNote(int noteId)
        {
            _notesDBRepository.DeleteNote(noteId);
        }

        public void UpdateNote(Note note, string username)
        {
            var noteFromDB = _notesDBRepository.GetById(note.Id);
            if (noteFromDB == null)
            {
                throw new Exception("Shopping list not found");//ilogger
            }
            if (noteFromDB.Author != username)
            {
                throw new Exception("User is trying to update foreign note");
            }

            _notesDBRepository.UpdateNote(note);
        }
    }
}
