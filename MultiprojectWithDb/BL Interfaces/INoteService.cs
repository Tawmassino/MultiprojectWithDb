using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface INoteService
    {
        NoteResponse AddNewNote(Note note);
        Note GetNote(string noteTitle);

        Note GetNoteById(int id);
        List<Note> GetUserNotes(int userId);
        void RemoveNote(int noteId);

        void UpdateNote(Note note, int userId);

    }
}
