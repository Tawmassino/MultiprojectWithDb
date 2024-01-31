using MultiprojectWithDb.API.DTOs;
using MultiprojectWithDb.DTOs;
using MultiprojectWithDB.BusinessLogic.BL_Interfaces;
using MultiprojectWithDB.DataAccessLayer.Entities;
using MultiprojectWithDB.MAIN.DTOs;

namespace MultiprojectWithDB.BusinessLogic.BL_Services
{
    public class NoteMapper : INoteMapper
    {//api projekto dalis

        //private readonly INoteMapper _mapper;

        //public NoteMapper(INoteMapper mapper)
        //{
        //   _mapper = mapper;
        //}

        // ==================== methods  ====================
        public Note Map(NoteCreateDTO dto, int userId) // dto -> model
        {
            return new Note
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Created = dto.Created,
                Updated = dto.Updated,
                Picture = dto.Picture,
                UserId = userId,
            };
        }

        public Note Map(NoteUpdateDTO dto, int userId) // dto -> model
        {
            var entity = new Note
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Updated = dto.Updated,
                Picture = dto.Picture,
                UserId = userId,
            };
            return entity;

        }

        public NoteGetDTO Map(Note model, int userId) // model -> dto
        {
            var entity = new NoteGetDTO
            {
                Id = model.Id,
                Title = model.Title,
                UserId = userId,
                Description = model.Description,

            };
            return entity;
        }

        public List<NoteGetDTO> Map(IEnumerable<Note> models, int userId) // models -> dtos
        {
            //return model.Select(Map).ToList(); // <-- negerai, nes reikia userId
            //return model.Select((x, i) => Map(x, i)).ToList(); //Sitas irgi negerai, nes reikia userId

            return models.Select(x => Map(x, userId)).ToList();
        }
    }
}
