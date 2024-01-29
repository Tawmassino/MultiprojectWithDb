using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface INoteService
    {
        NoteResponseDTO AddNewNote(Note note);
        Note GetNote(string noteTitle);

        void RemoveNote(int noteId);

        void UpdateNote(Note note, string username);

    }
}
