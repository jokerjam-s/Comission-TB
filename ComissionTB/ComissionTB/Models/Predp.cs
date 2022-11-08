using ComissionTB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Models
{
    [Table("tPredp")]
    [Display(Name = "Предписание")]
    public class Predp
    {
        // предписание
        [Key]
        [Display(Name = "Номер предписания")]
        public int prNo { get; set; }

        [Display(Name = "Текст предписания")]
        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "Текст предписания обязателен для заполнения!")]
        public string prText { get; set; }

        [Display(Name = "Основание")]
        public string osnova { get; set; }

        [Display(Name = "Примечание")]
        public string prim { get; set; }


        [Display(Name = "Дата исполнения")]
        [DataType(DataType.Date)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime prDate { get; set; }

        [Display(Name = "Пояснение исполнителя")]
        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "Текст пояснения обязателен для заполнения!")]
        public string prIspNote { get; set; }

        [Display(Name = "Дата исполнения")]
        [DataType(DataType.Date)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime prIspDate { get; set; }

        // link to akt
        public Akt akt { get; set; }

        // link to user
        public AppUsers appUser { get; set; }

        public Pom pom { get; set; }
    }
}
