using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class CreateCexViewModel
    {
        [Display(Name = "Код цеха")]
        public int id_cex { get; set; }

        [Display(Name = "Подразделение", Prompt = "Наименование подразделения")]
        [StringLength(100)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string cexName { get; set; }

        [Display(Name = "Руководитель")]
        public int UserId { get; set; }

        public IEnumerable<AppUsers> Users { get; set; }

    }
}
