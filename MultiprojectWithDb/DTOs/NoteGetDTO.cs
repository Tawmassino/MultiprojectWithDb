using MultiprojectWithDB.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.MAIN.DTOs
{
    public class NoteGetDTO
    {
        //getDTO validatoriu nereikia
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }



        [ForeignKey("UserId")]
        public User User { get; set; }//cia pasakome kad yra  User tipo lentele, cia ne stuleplis
        public int UserId { get; set; }//nurodo foreign key i user lentele, atskiras stulpelis



        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] Picture { get; set; }

    }
}
