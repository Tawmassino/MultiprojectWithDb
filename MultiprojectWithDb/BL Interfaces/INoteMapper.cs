using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Interfaces
{
    public interface INoteMapper
    {
        Note Map(NoteCreateDTO note, int userId);
    }
}
