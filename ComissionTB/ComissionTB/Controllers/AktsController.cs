using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComissionTB.Data;
using ComissionTB.Models;
using ComissionTB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Rotativa.AspNetCore;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using MailKit.Security;

namespace ComissionTB.Controllers
{
    public class AktsController : Controller
    {
        RoleManager<AppRoles> _roleManager;
        UserManager<AppUsers> _userManager;

        private readonly ComissionDbContext _context;

        public SecureSocketOptions Auto { get; private set; }

        public AktsController(ComissionDbContext context, RoleManager<AppRoles> roleManager, UserManager<AppUsers> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index(int? nYear)
        {
            if (nYear == null) nYear = DateTime.Now.Year;

            IEnumerable<Akt> akts = await _context.akt
                .Include(a => a.cex)
                .Include(p => p.predps)
                .Include(s => s.sostavs)
                .Where(a => a.aktDate.Year == (int)nYear)
                .ToListAsync();

            ViewBag.nYear = nYear;
            return View(akts);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Akt aktV = await _context.akt
                .Include(c => c.sostavs)
                .Include(c => c.cex)
                .Include(u => u.PredsId)
                .Include(u => u.SekrId)
                .FirstOrDefaultAsync(a => a.aktNo == id);

            Cex cx = await _context.cex
                .Include(u => u.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == aktV.cex.id_cex);


            aktV.cex.appUser = cx.appUser;

            IEnumerable<Predp> pr = _context.predp
                .Include(u => u.appUser)
                .Include(p => p.pom)
                .Where(p => p.akt.aktNo == id);


            aktV.predps = pr.ToList();
            //aktV.sostavs = st.ToList();

            var role = await _roleManager.Roles.SingleAsync(r => r.Name == "comission");

            AktDetailViewModel adm = new()
            {
                akt = aktV,
                appComiss = _userManager.GetUsersInRoleAsync("comission").Result,
                appIsp = _userManager.GetUsersInRoleAsync("ordinal").Result
            };

            return View(adm);
        }

        [Authorize(Roles = "admin,secr")]
        // новое предписание
        // GET: Akts/CreatePredp/5
        public async Task<IActionResult> CreatePredp(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Akt akt = await _context.akt
                .Include(c => c.cex)
                .FirstOrDefaultAsync(a => a.aktNo == id);

            CreateAktPredpViewModel crModel = new()
            {
                aktNo = (int)id,
                Users = _userManager.Users,
                pom = _context.pom
                    .Where(p => p.cex.id_cex == akt.cex.id_cex)
            };
            return View(crModel);
        }

        [Authorize(Roles = "admin,secr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePredp([Bind("aktNo,prDate,prText,osnova,prim,id_pom")] CreateAktPredpViewModel model)
        {
            if (ModelState.IsValid)
            {
                Predp predp = new()
                {
                    akt = await _context.akt
                        .FirstOrDefaultAsync(a => a.aktNo == model.aktNo),
                    prDate = model.prDate,
                    osnova = String.IsNullOrEmpty(model.osnova) ? " " : model.osnova, //тут раньше было основание не требуется
                    prText = model.prText,
                    prim = model.prim,

                    pom = await _context.pom.FindAsync(model.id_pom),
                    prIspNote = ""
                };

                _context.Add(predp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Detail), new { @id = model.aktNo });
            }

            return View(model);
        }

        [Authorize(Roles = "admin,secr")]
        // новое предписание
        // GET: Akts/EditPredp/5
        public async Task<IActionResult> EditPredp(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            Predp pred = await _context.predp
                .Include(a => a.akt)
                .Include(c => c.pom)
                .Include(a => a.appUser)
                .FirstOrDefaultAsync(p => p.prNo == id1);
            
            Akt akt = await _context.akt
                .Include(c => c.cex)
                .FirstOrDefaultAsync(a => a.aktNo == id2);

            CreateAktPredpViewModel crModel = new()
            {
                aktNo = (int)id2,
                Users = _userManager.Users,
                pom = _context.pom
                    .Where(p => p.cex.id_cex == akt.cex.id_cex),
                prNo = pred.prNo,
                prDate = pred.prDate,
                osnova = pred.osnova,
                prText = pred.prText,
                prim = pred.prim,
                UserId = (pred.appUser == null) ? 0 : pred.appUser.Id,
                id_pom = pred.pom.id_pom                
            };
            return View(crModel);
        }

        [Authorize(Roles = "admin,secr")]
        [HttpPost]
        // новое предписание
        // GET: Akts/CreatePredp/5
        public async Task<IActionResult> EditPredp([Bind("prNo,aktNo,prDate,prText,osnova,prim,id_pom,UserId")] CreateAktPredpViewModel model)
        {
            if (ModelState.IsValid)
            {
                Predp predp = new()
                {
                    prNo = model.prNo,
                    appUser = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.Id == model.UserId),
                    akt = await _context.akt
                        .FirstOrDefaultAsync(a => a.aktNo == model.aktNo),
                    prDate = model.prDate,
                    osnova = String.IsNullOrEmpty(model.osnova) ? " " : model.osnova, //тут раньше было основание не требуется
                    prText = model.prText,
                    prim = model.prim,

                    pom = await _context.pom.FindAsync(model.id_pom),
                    prIspNote = ""
                };

                _context.predp.Update(predp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Detail), new { @id = model.aktNo });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult getAkt(int? nYear)
        {
            if(nYear == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index), new { @nYear = (int)nYear });
        }


        [Authorize(Roles = "admin,secr")]
        // GET
        public async Task<IActionResult> Create()
        {
            IEnumerable<AppUsers> pr = _userManager.GetUsersInRoleAsync("preds").Result;
            IEnumerable<AppUsers> sc = _userManager.GetUsersInRoleAsync("secr").Result;

            CreateAktViewModel crAktModel = new()
            {
                cex = await _context.cex.ToListAsync(),
                aktDate = DateTime.Now.Date,
                appUserPrs = pr.Where(p => p.userDismis == null),
                appUserScr = sc.Where(s => s.userDismis == null)
            };

            return View(crAktModel);
        }

        [Authorize(Roles = "admin,secr")]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("aktNum,aktDate,aktText,id_cex,pred_Id,secr_Id")] CreateAktViewModel aktModel)
        {
            if (ModelState.IsValid)
            {
                Akt akt = new Akt
                {
                    aktDate = aktModel.aktDate,
                    aktNum = aktModel.aktNum,
                    cex = await _context.cex
                        .Include(u => u.appUser)
                        .FirstOrDefaultAsync(c => c.id_cex == aktModel.id_cex),
                    PredsId = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.Id == aktModel.pred_Id),
                    SekrId = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.Id == aktModel.secr_Id),
                    SoglCnt = 2,
                    SoglHave = 1,
                    SoglPreds = false,
                    SoglSecr = true
                };

                _context.Add(akt);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(aktModel);
        }

        [Authorize(Roles = "admin,secr")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akt = await _context.akt
                .Include(c => c.cex)
                .FirstOrDefaultAsync(m => m.aktNo == id);

            if (akt == null)
            {
                return NotFound();
            }
            return View(akt);
        }

        [Authorize(Roles = "admin,secr")]
        // POST: Objs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            Akt akt = await _context.akt
                .FirstOrDefaultAsync(o => o.aktNo == id);

            var predp = await _context.predp
                .Where(p => p.akt.aktNo == id).ToListAsync();

            foreach (var item in predp) {
                _context.Remove(item);
            }

            _context.akt.Remove(akt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin,secr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePredp(int? aktNo, int? prNo)
        {
            if(aktNo == null || prNo == null)
            {
                return NotFound();
            }

            Predp predp = await _context.predp
                .FindAsync(prNo);

            _context.predp.Remove(predp);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        // 
        //GET: Выставление оценки
        public async Task<IActionResult> SetOcen(int? aktNo, string ocenka)
        {
            if (aktNo == null) return NotFound();

            Akt akt = await _context.akt
                .FindAsync(aktNo);

            akt.ocenka = ocenka;

            _context.akt.Update(akt);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        //public IActionResult Ocenka(int? id, int? id2)
        //{
        //    if(id == null || id2 == null)
        //    {
        //        return NotFound();
        //    }

        //    OcenkaViewModel oModel = new()
        //    {
        //        prNo = (int)id,
        //        aktNo = (int)id2
        //    };

        //    return View(oModel);
        //}

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ocenka([Bind("aktNo,prNo,ocenka")] OcenkaViewModel oModel)
        {
            if (ModelState.IsValid)
            {
                Predp predp = await _context.predp
                    .FindAsync(oModel.prNo);

                _context.predp.Update(predp);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Detail), new { @id = oModel.aktNo });
            }

            return View(oModel);
        }

        // GET: ExecPredp/5/6
        public IActionResult ExecPredp(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            ExecPredpViewModel exModel = new()
            {
                prNo = (int)id,
                aktNo = (int)id2,
                prIspDate = DateTime.Now.Date,
                prIspNote = ""
            };

            return View(exModel);
        }

        
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExecPredpAsync([Bind("aktNo,prNo,prIspDate,prIspNote")] ExecPredpViewModel exModel)
        {
            if (ModelState.IsValid)
            {
                Predp predp = await _context.predp
                    .FindAsync(exModel.prNo);

                predp.prIspDate = exModel.prIspDate;
                predp.prIspNote = exModel.prIspNote;
                _context.Update(predp);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Detail), new { @id = exModel.aktNo });
            }

            return View(exModel);
        }

        // GET: Prints/5
        public async Task<IActionResult> Prints(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Akt akt = await _context.akt
                .Include(c => c.sostavs)
                .Include(c => c.cex)
                .Include(p => p.PredsId)
                .Include(s => s.SekrId)
                .FirstOrDefaultAsync(a => a.aktNo == id);

            IEnumerable<Predp> pr = _context.predp
                .Include(u => u.appUser)
                .Include(p => p.pom)
                .OrderBy(p => p.prDate)
                .Where(p => p.akt.aktNo == id);

            akt.predps = pr.ToList();

            Cex cx = await _context.cex
                .Include(a => a.appUser)
                .FirstOrDefaultAsync(a => a.id_cex == akt.cex.id_cex);

            AppUsers u = await _userManager.Users
                .Include(d => d.dolgn)
                .FirstOrDefaultAsync(u => u.Id == cx.appUser.Id);

            akt.cex.appUser = u;

            AppUsers user = await _userManager.Users
                .Include(c => c.dolgn)
                .FirstOrDefaultAsync(c => c.Id == akt.PredsId.Id);
            akt.PredsId.dolgn = user.dolgn;

            user = await _userManager.Users
                .Include(c => c.dolgn)
                .FirstOrDefaultAsync(c => c.Id == akt.SekrId.Id);
            akt.SekrId.dolgn = user.dolgn;

            foreach(var item in akt.sostavs)
            {
                Sostav st = await _context.sostav
                    .Include(c => c.user)
                    .FirstOrDefaultAsync(c => c.id_st == item.id_st);

                user = await _userManager.Users
                    .Include(c => c.dolgn)
                    .FirstOrDefaultAsync(c => c.Id == st.user.Id);

                item.user = user;
            }

            return new ViewAsPdf(akt);
        }

        [HttpPost]
        public async Task<IActionResult> AddSostav(int? aktNo, int? com_id)
        {
            if(aktNo == null || com_id == null)
            {
                NotFound();
            }

            Sostav st = new()
            {
                akt = await _context.akt
                    .FirstAsync(a => a.aktNo == aktNo),
                user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == com_id)
            };

            Akt akt = st.akt;

            akt.SoglCnt++;

            _context.sostav.Add(st);
            _context.akt.Update(akt);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        [HttpPost]
        public async Task<IActionResult> delSost(int? aktNo, int? id_st)
        {
            if(aktNo== null || id_st == null)
            {
                return NotFound();
            }

            Sostav st = await _context.sostav
                .Include(s => s.akt)
                .FirstAsync(s => s.id_st == id_st);

            Akt akt = st.akt;
            akt.SoglCnt--;
            if (st.isSogl != null)
                if (st.isSogl == true)
                    akt.SoglHave--;

            _context.sostav.Remove(st);
            _context.akt.Update(akt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        [HttpPost]
        public async Task<IActionResult> SetOtv(int? aktNo, int? prNo, int? isp_id)
        {
            if (aktNo == null || prNo == null || isp_id == null)
            {
                NotFound();
            }

            Predp pr = await _context.predp.FindAsync(prNo);
            pr.appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == isp_id);

            Akt akt = await _context.akt.FindAsync(aktNo);

            _context.predp.Update(pr);
            await _context.SaveChangesAsync();

            var mSet = await _context.mailSetting
                .FirstOrDefaultAsync();

            var client = new SmtpClient();

            try
            {
                var emailMsg = new MimeMessage();
                emailMsg.From.Add(new MailboxAddress("ИАС Охрана Труда", mSet.PostMail));
                emailMsg.To.Add(new MailboxAddress(pr.appUser.GetFio(), pr.appUser.Email));
                emailMsg.Subject = "Акт-предписание";
                emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Вам назначено предписание по акту №" + akt.aktNum.ToString() + ", которое необходимо выполнить не позднее указанного срока." + "<br>" + "Войти в приложение: " + $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Akts/Detail/{akt.aktNo}" + "<br>" + " " + "<br>" + "С уважением" + "<br>" + "Информационная-аналитическая система Охрана Труда" + "<br>" + "МУП АГО Ангарский Водоканал"
                };


                await client.ConnectAsync("ntavk1", 25, Auto);
                await client.AuthenticateAsync("comissiontb@avk.irtel.ru", "aecc57Yk8");

                await client.SendAsync(emailMsg);
            }
            catch { }
            finally
            {
                await client.DisconnectAsync(true);
            }

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }
        

        public async Task<IActionResult> OpenPredp()
        {
            IEnumerable<Predp> predpList = await _context.predp
                .Include(a => a.akt)
                .Include(p => p.pom)
                .Include(u => u.appUser)
                .Where(p => String.IsNullOrEmpty(p.prIspNote))
                .OrderBy(a => a.akt.aktNum)
                .ToListAsync();

            foreach(var item in predpList)
            {
                Akt ac = await _context.akt
                    .Include(c => c.cex)
                    .FirstOrDefaultAsync(a => a.aktNo == item.akt.aktNo);

                item.akt.cex = ac.cex;
            }

            return View(predpList);
        }

        public async Task<IActionResult> PrintOpenPredp()
        {
            IEnumerable<Predp> predpList = await _context.predp
                .Include(a => a.akt)
                .Include(p => p.pom)
                .Include(u => u.appUser)
                .Where(p => String.IsNullOrEmpty(p.prIspNote))
                .OrderBy(s => s.prDate)
                .OrderBy(a => a.akt.aktNum)
                .ToListAsync();

            foreach (var item in predpList)
            {
                Akt ac = await _context.akt
                    .Include(c => c.cex)
                    .FirstOrDefaultAsync(a => a.aktNo == item.akt.aktNo);

                item.akt.cex = ac.cex;
            }

            return new ViewAsPdf(predpList);
        }


        public async Task<IActionResult> soglPreds(int? aktNo)
        {
            if (aktNo == null) return NotFound();

            Akt akt = await _context.akt.FindAsync(aktNo);

            akt.SoglPreds = true;
            akt.SoglHave++;

            _context.akt.Update(akt);
            await _context.SaveChangesAsync();

            await sendMail(aktNo);

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        public async Task<IActionResult> soglSecr(int? aktNo)
        {
            if (aktNo == null) return NotFound();

            /*
            Akt akt = await _context.akt.FindAsync(aktNo);

            akt.SoglSecr = true;
            //akt.SoglHave++;

            _context.akt.Update(akt);
            await _context.SaveChangesAsync();
            */

            Akt akt = await _context.akt
                .Include(c => c.cex)
                .Include(p => p.PredsId)
                .Include(s => s.SekrId)
                .FirstOrDefaultAsync(a => a.aktNo == aktNo);

            
            var mSetP = await _context.mailSetting
            .FirstOrDefaultAsync();

            Cex cexP = await _context.cex
            .Include(u => u.appUser)
            .FirstOrDefaultAsync(c => c.id_cex == akt.cex.id_cex);

            var clientP = new SmtpClient();

            try
            {
                var emailMsg = new MimeMessage();
                emailMsg.From.Add(new MailboxAddress("ИАС Охрана Труда", mSetP.PostMail));
                emailMsg.To.Add(new MailboxAddress(akt.PredsId.GetFio(), akt.PredsId.Email));
                emailMsg.Subject = "Акт-предписание";
                emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Подготовлен акт №" + akt.aktNum.ToString() + ", Вам необходимо согласовать акт-предписание." + " <br>" + "Войти в приложение: " + $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Akts/Detail/{akt.aktNo}" + "<br>" + " " + "<br>" + "С уважением" + "<br>" + "Информационная-аналитическая система Охрана Труда" + "<br>" + "МУП АГО Ангарский Водоканал"
                };

                await clientP.ConnectAsync("ntavk1", 25, Auto);
                await clientP.AuthenticateAsync("comissiontb@avk.irtel.ru", "aecc57Yk8");

                await clientP.SendAsync(emailMsg);
            }
            catch { }
            finally
            {
                await clientP.DisconnectAsync(true);
            }

          
            Cex cex = await _context.cex
                .Include(u => u.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == akt.cex.id_cex);

            var mSet = await _context.mailSetting
                .FirstOrDefaultAsync();

            var client = new SmtpClient();

            try
            {
                var emailMsg = new MimeMessage();
                emailMsg.From.Add(new MailboxAddress("ИАС Охрана Труда", mSet.PostMail));
                emailMsg.To.Add(new MailboxAddress(cex.appUser.GetFio(), cex.appUser.Email));
                emailMsg.Subject = "Акт-предписание";
                emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Вам выписан акт №" + akt.aktNum.ToString() + ", необходимо назначить ответственных за устранение замечаний по предписанию." + "<br>" + "Войти в приложение: " + $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Akts/Detail/{akt.aktNo}" + "<br>" + " " + "<br>" + "С уважением" + "<br>" + "Информационная-аналитическая система Охрана Труда" + "<br>" + "МУП АГО Ангарский Водоканал"

                };

                await client.ConnectAsync("ntavk1", 25, Auto);
                await client.AuthenticateAsync("comissiontb@avk.irtel.ru", "aecc57Yk8");

                await client.SendAsync(emailMsg);
            }
            catch { }
            finally
            {
                await client.DisconnectAsync(true);
            }

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }

        public async Task<IActionResult> soglComm(int? aktNo, int? id_st)
        {
            if (aktNo == null || id_st == null) return NotFound();

            Akt akt = await _context.akt.FindAsync(aktNo);
            Sostav st = await _context.sostav.FindAsync(id_st);

            st.isSogl = true;
            akt.SoglHave++;

            _context.akt.Update(akt);
            _context.sostav.Update(st);
            await _context.SaveChangesAsync();

            await sendMail(aktNo);

            return RedirectToAction(nameof(Detail), new { @id = aktNo });
        }


        public async Task sendMail(int? aktNo)
        {
            Akt akt = await _context.akt
                .Include(c => c.cex)
                .Include(p => p.PredsId)
                .Include(s => s.SekrId)
                .FirstOrDefaultAsync(a => a.aktNo == aktNo);

            // если комиссия согласовала
            if(akt.SoglCnt == akt.SoglHave + 1)
            {
                var mSetP = await _context.mailSetting
                .FirstOrDefaultAsync();

                Cex cexP = await _context.cex
                .Include(u => u.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == akt.cex.id_cex);

                var clientP = new SmtpClient();

                try
                {
                    var emailMsg = new MimeMessage();
                    emailMsg.From.Add(new MailboxAddress("ИАС Охрана Труда", mSetP.PostMail));
                    emailMsg.To.Add(new MailboxAddress(akt.PredsId.GetFio(), akt.PredsId.Email));
                    emailMsg.Subject = "Акт-предписание";
                    emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = "Подготовлен акт №" + akt.aktNum.ToString() + ", Вам необходимо согласовать акт-предписание." +" <br>" + "Войти в приложение: " + $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Akts/Detail/{akt.aktNo}" + "<br>" + " " + "<br>" + "С уважением" + "<br>"+ "Информационная-аналитическая система Охрана Труда" + "<br>" + "МУП АГО Ангарский Водоканал"
                    };

                    await clientP.ConnectAsync("ntavk1", 25, Auto);
                    await clientP.AuthenticateAsync("comissiontb@avk.irtel.ru", "aecc57Yk8");

                    await clientP.SendAsync(emailMsg);
                }
                catch { }
                finally
                {
                    await clientP.DisconnectAsync(true);
                }

            }

            // выход если согласован не всеми
            if (akt.SoglCnt != akt.SoglHave) return;

            Cex cex = await _context.cex
                .Include(u => u.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == akt.cex.id_cex);
            
            var mSet = await _context.mailSetting
                .FirstOrDefaultAsync();

            var client = new SmtpClient();

            try
            {
                var emailMsg = new MimeMessage();
                emailMsg.From.Add(new MailboxAddress("ИАС Охрана Труда", mSet.PostMail));
                emailMsg.To.Add(new MailboxAddress(cex.appUser.GetFio(), cex.appUser.Email));
                emailMsg.Subject = "Акт-предписание";
                emailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Вам выписан акт №" + akt.aktNum.ToString() + ", необходимо назначить ответственных за устранение замечаний по предписанию." + "<br>" + "Войти в приложение: " + $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Akts/Detail/{akt.aktNo}" + "<br>" + " " + "<br>" + "С уважением" + "<br>" + "Информационная-аналитическая система Охрана Труда" + "<br>" + "МУП АГО Ангарский Водоканал"

                };

                await client.ConnectAsync("ntavk1", 25, Auto);
                await client.AuthenticateAsync("comissiontb@avk.irtel.ru", "aecc57Yk8");

                await client.SendAsync(emailMsg);
            }
            catch { }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
