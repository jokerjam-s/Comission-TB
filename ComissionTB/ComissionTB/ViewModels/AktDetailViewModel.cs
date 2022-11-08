using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;

namespace ComissionTB.ViewModels
{
    public class AktDetailViewModel
    {
        public Akt akt { get; set; }

        public int com_id { get; set; }
        public int isp_id { get; set; }

        public IEnumerable<AppUsers> appComiss;
        
        public IEnumerable<AppUsers> appIsp;

    }
}
