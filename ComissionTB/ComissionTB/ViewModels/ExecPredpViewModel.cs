using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class ExecPredpViewModel
    {
        public int aktNo { get; set; }

        public int prNo { get; set; }

        [Display(Name = "Пояснение исполнителя")]
        [DataType(DataType.MultilineText)]
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public string prIspNote { get; set; }

        [Display(Name = "Дата исполнения")]
        [DataType(DataType.Date)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public DateTime prIspDate { get; set; }
    }
}
