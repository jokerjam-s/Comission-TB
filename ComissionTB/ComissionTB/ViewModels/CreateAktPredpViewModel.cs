using ComissionTB.Data;
using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class CreateAktPredpViewModel
    {

        public int aktNo { get; set;}

        public int prNo { get; set; }
        public IEnumerable<AppUsers> Users { get; set; }

        [Display(Name = "Текст предписания")]
        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public string prText { get; set; }

        [Display(Name = "Основание")]
        public string osnova { get; set; }

        [Display(Name = "Примечание")]
        public string prim { get; set; }

        [Display(Name = "Дата исполнения")]
        [DataType(DataType.Date)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public DateTime prDate { get; set; }

        // исполниитель
        public int UserId { get; set; }

        // помещение
        public int id_pom { get; set; }

        public IEnumerable<Pom> pom;

    }
}
