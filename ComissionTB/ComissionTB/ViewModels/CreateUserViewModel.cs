using ComissionTB.Data;
using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class CreateUserViewModel
    {

        public IEnumerable<Dolgn> dolgnList;
        public IEnumerable<Cex> cexList;

        [Display(Name = "Таб. №")]
        public int tabNo { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [MinLength(2, ErrorMessage = "Минимальная длина фамилии 2 символа!")]
        public string userFio { get; set; }

        [Display(Name = "Имя")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени 2 символа!")]
        public string userFirstName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(50)]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        [MinLength(2, ErrorMessage = "Минимальная длина отчества 2 символа!")]
        public string userSecName { get; set; }

        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата приема на работу обязательна для заполнения!")]
        public DateTime userPriem { get; set; }

        // связь с должностью
        public int id_dl { get; set; }
        public int id_cex { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string Email { get; set; }

     
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string Password { get; set; }

        
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Required(ErrorMessage = "Обязательно для заполнения!")]
        public string PasswordConfirm { get; set; }
        
    }
}
