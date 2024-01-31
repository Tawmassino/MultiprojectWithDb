using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface INoteMapper
    {
        Note Map(NoteCreateDTO note, int userId);//create
        Note Map(NoteUpdateDTO dto, int userId);//update
        NoteGetDTO Map(Note note, int userId);//get
        List<NoteGetDTO> Map(IEnumerable<Note> model, int userId);// ???

    }
}
