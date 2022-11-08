using ComissionTB.Data;
using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class EditUserViewModel
    {
        public IEnumerable<Dolgn> dolgnList;
        public IEnumerable<Cex> cexList;

        public int Id { get; set; }

        [Display(Name = "Таб. №")]
        public int tabNo { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(50)]
        [Required(ErrorMessage = "ФИО обязательно для заполнения!")]
        [MinLength(2, ErrorMessage = "Минимальная длина ФИО 2 символов!")]
        public string userFio { get; set; }

        [Display(Name = "Имя")]
        [StringLength(50)]
        [Required(ErrorMessage = "Имя обязательно для заполнения!")]
        [MinLength(2, ErrorMessage = "Минимальная длина Имени 2 символов!")]
        public string userFirstName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(50)]
        public string userSecName { get; set; }

        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата приема на работу обязательна для заполнения!")]
        public DateTime userPriem { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int id_dl { get; set; }
        public int id_cex { get; set; }
    }
}
