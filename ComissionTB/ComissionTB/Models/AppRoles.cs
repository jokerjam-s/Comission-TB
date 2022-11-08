using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ComissionTB.Data;

namespace ComissionTB.Models
{
    public class AppRoles: IdentityRole<int>
    {
        [Display(Name = "Расшифровка")]
        [StringLength(30)]
        public string Descript { get; set; }
    }
}
