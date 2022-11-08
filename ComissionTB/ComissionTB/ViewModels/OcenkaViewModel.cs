using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class OcenkaViewModel
    {
        public int prNo { get; set; }

        public int aktNo { get; set; }

        [Display(Name = "Оценка")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть в пределах [1..5]")]
        public int ocenka { get; set; }
    }
}
