using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Models
{
    [Display(Name = "Подразделение")]
    public class Cex
    {
        // Цех
        [Key]
        [Display(Name = "Код цеха")]
        public int id_cex { get; set; }

        [Display(Name = "Подразделение", Prompt = "Наименование подразделения")]
        [StringLength(100)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string cexName { get; set; }

        [Display(Name = "Руководитель")]
        public AppUsers appUser { get; set; }

        // связь с актами
        public ICollection<Akt> akts { get; set; }

        // связь с помещениями
        public ICollection<Pom> pom { get; set; }

        public Cex()
        {
            akts = new List<Akt>();
        }
                
    }
}
