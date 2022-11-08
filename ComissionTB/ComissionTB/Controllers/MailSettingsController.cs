using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;
using ComissionTB.Data;

namespace ComissionTB.Controllers
{
    public class MailSettingsController : Controller
    {

        private readonly ComissionDbContext _context;

        public MailSettingsController(ComissionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            MailSettings ms = _context.mailSetting.FirstOrDefault();

            if (ms == null)
            {
                ms = new MailSettings();
            }

            return View(ms);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([Bind("mail_id,PostMail,PostSmtp,PostPort,PostPass")] MailSettings mailSet)
        {
            int msCnt = _context.mailSetting.Count();

            if(ModelState.IsValid)
            {
                if (msCnt > 0)
                {
                    _context.mailSetting.Update(mailSet);
                }
                else
                {
                    _context.mailSetting.Add(mailSet);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
