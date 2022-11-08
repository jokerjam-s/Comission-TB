using ComissionTB.Data;
using ComissionTB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.ViewModels
{
    public class AppUserView
    {
        public AppUsers user { get; set; }
        public string cexName { get; set; }
    }
}
