using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiprojectWithDB.DataAccessLayer.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }



        [ForeignKey(nameof(User))]
        public int UserId { get; set; }//nurodo foreign key i user lentele, atskiras stulpelis, pasako KURI  useri
        public User User { get; set; }//cia pasakome kad yra  User tipo lentele, cia ne stuleplis, CIA DEL MUSU PATOGUMO, neegzistuoja DB, nuorodoa KAIP uzkrauti useri





        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public byte[]? Picture { get; set; }

        //[ForeignKey("UserId")]
        //public User User { get; set; }//cia pasakome kad yra  User tipo lentele, cia ne stuleplis
        //public int UserId { get; set; }//nurodo foreign key i user lentele, atskiras stulpelis

    }
}
