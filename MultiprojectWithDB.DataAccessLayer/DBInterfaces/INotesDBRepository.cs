using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.DBInterfaces
{
    public interface INotesDBRepository
    {
        //add new Note
        int AddNewNote(Note newNote);

        //get All
        IEnumerable<Note> GetAllNotesByUser(int id);

        //get by id
        Note GetNoteById(int id);

        //update
        void UpdateNote(Note note);

        //delete
        void DeleteNote(int id);
        Note GetNoteByTitle(string noteTitle);
    }
}
