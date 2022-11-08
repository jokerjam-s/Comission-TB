using ComissionTB.Data;
using ComissionTB.Models;
using ComissionTB.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionTB.Controllers
{
    public class UsersController : Controller
    {
        UserManager<AppUsers> _userManager;
        private readonly ComissionDbContext _context;

        public UsersController(ComissionDbContext context, UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            List<AppUserView> usersView = new List<AppUserView>();
            List<AppUsers> users = _userManager.Users.Include(d => d.dolgn).ToList();

            foreach(var item in users)
            {
                usersView.Add(new AppUserView {
                    user = item, 
                    cexName = _context.cex.Find(item.id_cex).cexName
                });
            }

            return View(usersView);
        }
        

        public IActionResult Create() {
            CreateUserViewModel model = new CreateUserViewModel();
            model.dolgnList = _context.dolgn;
            model.cexList = _context.cex;
            model.userPriem = DateTime.Now.Date;

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Dolgn dlgn = _context.dolgn.Where(d => d.id_dl == model.id_dl).FirstOrDefault();

                AppUsers user = new AppUsers {
                    Email = model.Email,
                    UserName = model.Email,
                    userFio = model.userFio,
                    userFirstName = model.userFirstName,
                    userSecName = model.userSecName,
                    userPriem = model.userPriem,
                    dolgn = dlgn,
                    id_cex = model.id_cex
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null) return NotFound();

            AppUsers user = await _userManager
                .Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (user == null)
            {
                return NotFound();
            }

            EditUserViewModel model = new()
            {
                Id = user.Id,
                Email = user.Email,
                userFio = user.userFio,
                userFirstName = user.userFirstName,
                userSecName = user.userSecName,
                userPriem = user.userPriem,
                dolgnList = await _context.dolgn.ToListAsync(),
                id_dl = user.dolgn.id_dl,
                id_cex = user.id_cex,
                cexList = await _context.cex.ToListAsync()
            };
            return View(model);
            
            //return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUsers user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == model.Id);

                if(user.Email != model.Email)
                {
                    var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                }

                if (user != null)
                {
                    user.UserName = model.Email;
                    user.userFio = model.userFio;
                    user.userFirstName = model.userFirstName;
                    user.userSecName = model.userSecName;
                    user.userPriem = model.userPriem;
                    user.dolgn = await _context.dolgn.FindAsync(model.id_dl);
                    user.id_cex = model.id_cex;

                    
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUsers user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
