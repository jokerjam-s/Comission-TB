using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Models
{
    [Display(Name = "Настройки отправки")]
    public class MailSettings
    {
        [Key]
        public int mail_id { get; set; }

        [Display(Name = "Почта отправителя")]
        [MaxLength(250)]
        public string PostMail { get; set; }

        [Display(Name = "SMTP сервер")]
        [MaxLength(250)]
        public string PostSmtp { get; set; }

        [Display(Name = "Порт")]
        public int PostPort { get; set; }

        [Display(Name = "Пароль")]
        public string PostPass { get; set; }

    }
}
