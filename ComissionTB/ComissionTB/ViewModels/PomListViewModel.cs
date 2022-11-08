using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;

namespace ComissionTB.ViewModels
{
    public class PomListViewModel
    {
        public Cex cex { get; set; }

        public IEnumerable<Pom> pomList { get; set; }
    }
}
