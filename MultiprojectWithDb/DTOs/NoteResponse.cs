using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class NoteResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public NoteResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public NoteResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
