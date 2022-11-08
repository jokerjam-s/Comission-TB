using ComissionTB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Models
{
    [Table("tSostav")]
    [Display(Name = "Состав комисси")]
    public class Sostav
    {
        [Key]
        public int id_st { get; set; }

        public Akt akt { get; set; }

        public AppUsers user { get; set; }

        // признак согласования
        public bool? isSogl { get; set; }

    }
}
