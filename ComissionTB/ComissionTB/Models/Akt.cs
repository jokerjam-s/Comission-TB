using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Models
{
    // составленные акты
    [Table("tAkt")]
    [Display(Name = "Акты обследования")]
    public class Akt
    {
        [Key]
        public int aktNo { get; set; }

        [Display(Name = "Номер акта")]
        [Range(1,int.MaxValue, ErrorMessage = "Номер акта обязателен для заполнения. Минимальное значение 1.")]
        public int aktNum { get; set; }

        [Display(Name = "Дата акта")]
        [DataType(DataType.DateTime)]
        [UIHint("Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime aktDate { get; set; }

        [Display(Name = "Оценка")]
        [MinLength(50)]
        public string ocenka { get; set; }

        //признаки согласования
        public int SoglCnt { set; get; }

        public int SoglHave { set; get; }

        public bool? SoglPreds { get; set; }

        public bool? SoglSecr { get; set; }

        // связь с цехом
        public Cex cex { get; set; }

        [Display(Name = "Председатель")]
        public AppUsers PredsId { get; set; }

        [Display(Name = "Секретарь")]
        public AppUsers SekrId { get; set; }

        // связь с предписаниями
        public ICollection<Predp> predps { get; set; }

        public ICollection<Sostav> sostavs { get; set; }



        public Akt()
        {
            predps = new List<Predp>();
            sostavs = new List<Sostav>();
        }
    }
}
