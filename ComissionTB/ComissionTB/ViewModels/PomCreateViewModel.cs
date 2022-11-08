using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class PomCreateViewModel
    {
        // помещение
        [Key]
        [Display(Name = "Код помещения")]
        public int id_pom { get; set; }

        [Display(Name = "Помещение", Prompt = "Название помещения")]
        [StringLength(100)]
        [Required(ErrorMessage = "Обязателено для заполнения!")]
        public string pomName { get; set; }

        // link to cex
        public int id_cex { get; set; }
    }
}
