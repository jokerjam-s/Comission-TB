using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;
using Microsoft.AspNetCore.Identity;
using ComissionTB.Data;

namespace ComissionTB.Models
{
    [Display(Name = "Сотрудник")]
    public class AppUsers: IdentityUser<int>
    {
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

        [Display(Name = "Дата увольнения")]
        [DataType(DataType.Date)]
        public DateTime? userDismis { get; set; }

        // связь с должностью
        public Dolgn dolgn { get; set; }

        public int id_cex { get; set; }

        public ICollection<Sostav> sostavs { get; set; }

        public string GetFio()
        {
            return userFio + " "
                + userFirstName.Substring(0, 1) + ". "
                + userSecName.Substring(0, 1);
        }
    }
}
