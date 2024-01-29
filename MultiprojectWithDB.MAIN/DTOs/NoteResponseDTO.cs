using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class NoteResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public NoteResponseDTO(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public NoteResponseDTO(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
