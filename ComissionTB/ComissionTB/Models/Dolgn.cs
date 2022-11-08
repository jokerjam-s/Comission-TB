using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;

namespace ComissionTB.Data
{
    // Должности
    [Table("tDolgn")]
    [Display(Name = "Должность")]
    public class Dolgn
    {
        [Key]
        [Display(Name = "Код должности")]
        public int id_dl { get; set; }

        [Display(Name = "Должность", Prompt = "Наименование должности")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string dlName { get; set; }

        public ICollection<AppUsers> users { get; set; }

        public Dolgn()
        {
            users = new List<AppUsers>();
        }
    }
}
