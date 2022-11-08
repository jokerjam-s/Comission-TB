using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class CreateAktViewModel
    {
        public IEnumerable<Cex> cex;
        public IEnumerable<AppUsers> appUserPrs;
        public IEnumerable<AppUsers> appUserScr;

        public int aktNo { get; set; }

        [Display(Name = "Номер акта")]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public int aktNum { get; set; }

        [Display(Name = "Дата акта")]
        [DataType(DataType.DateTime)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public DateTime aktDate { get; set; }

        public int? id_cex { get; set; }

        public int pred_Id { get; set; }

        public int secr_Id { get; set; }

        public int SoglCnt { set; get; }

        public int SoglHave { set; get; }

        public bool? SoglPreds { get; set; }

        public bool? SoglSecr { get; set; }
    }
}
