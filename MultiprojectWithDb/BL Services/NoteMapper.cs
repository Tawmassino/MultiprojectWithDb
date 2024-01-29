using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.BusinessLogic.BL_Services
{
    public class NoteMapper : INoteMapper
    {//api projekto dalis
        public Note Map(NoteCreateDTO note, int userId)
        {
            return new Note
            {
                //kur deti userID?
                Title = note.Title,
                Description = note.Description,
                Category = note.Category,
                Author = note.Author,
                Created = note.Created,
                Updated = note.Updated,
                Picture = note.Picture,
            };
        }



    }
}
