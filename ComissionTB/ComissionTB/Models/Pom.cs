using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

[Table("tPom")]
[Display(Name = "Помещение")]
public class Pom
{
    // помещение
    [Key]
    [Display(Name = "Код помещения")]
    public int id_pom { get; set; }

    [Display(Name = "Помещение", Prompt = "Название помещения")]
    [StringLength(100)]
    [Required(ErrorMessage = "Наименование помещения обязательно для заполнения!")]
    public string pomName { get; set; }

    // link to cex
    public Cex cex { get; set; }
}