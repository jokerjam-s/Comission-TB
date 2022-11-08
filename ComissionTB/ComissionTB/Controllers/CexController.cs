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

namespace ComissionTB.Controllers
{
    public class CexController : Controller
    {
        private readonly ComissionDbContext _context;
        private readonly UserManager<AppUsers> _users;
        private readonly RoleManager<AppRoles> _roles;

        public CexController(UserManager<AppUsers> users, RoleManager<AppRoles> roles, ComissionDbContext context)
        {
            _context = context;
            _users = users;
            _roles = roles;
        }

        // GET: Cex
        public async Task<IActionResult> Index()
        {
            return View(await _context.cex.Include(c => c.appUser).ToListAsync());
        }

        // GET: Cex/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cex = await _context.cex
                .Include(c => c.appUser)
                .FirstOrDefaultAsync(m => m.id_cex == id);

            if (cex == null)
            {
                return NotFound();
            }

            return View(cex);
        }

        // GET: Cex/Create
        public async Task<IActionResult> Create()
        {
            CreateCexViewModel crCex = new()
            {
                Users = await _users.Users
                    .Where(c => c.userDismis == null)
                    .ToListAsync()
            };

            return View(crCex);
        }

        // POST: Cex/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_cex,cexName,UserId")] CreateCexViewModel cex)
        {
            if (ModelState.IsValid)
            {
                AppUsers user = await _users.Users
                    .FirstOrDefaultAsync(u => u.Id == cex.UserId);
                    
                Cex newCex = new()
                {
                    cexName = cex.cexName,
                    appUser = user
                };

                await _users.AddToRoleAsync(user, "npodr");

                _context.Add(newCex);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cex);
        }

        // GET: Cex/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cex = await _context.cex
                .Include(c => c.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == id);

            AppUsers user = await _users.Users
                .FirstOrDefaultAsync(u => u.Id == cex.appUser.Id);
                
            await _users.AddToRoleAsync(user, "npodr");

            if (cex == null)
            {
                return NotFound();
            }

            CreateCexViewModel createCex = new()
            {
                id_cex = cex.id_cex,
                cexName = cex.cexName,
                UserId = cex.appUser.Id,
                Users = await _users.Users
                    .Where(c => c.userDismis == null)
                    .ToListAsync()
            };

            return View(createCex);
        }

        // POST: Cex/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_cex,cexName,UserId")] CreateCexViewModel cex)
        {
            if (id != cex.id_cex)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Cex crCex = new()
                {
                    cexName = cex.cexName,
                    id_cex = cex.id_cex,
                    appUser = await _users.Users
                        .FirstOrDefaultAsync(u => u.Id == cex.UserId)
                };

                try
                {
                    _context.Update(crCex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CexExists(crCex.id_cex))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cex);
        }

        // GET: Cex/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cex = await _context.cex
                .FirstOrDefaultAsync(m => m.id_cex == id);
            if (cex == null)
            {
                return NotFound();
            }

            return View(cex);
        }

        // POST: Cex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cex = await _context.cex.FindAsync(id);
            _context.cex.Remove(cex);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Cex/PomList/5
        public async Task<IActionResult> Pom(int? id)
        {
            if(id == null)
            {
                NotFound();
            }

            PomListViewModel pm = new()
            {
                cex = await _context.cex.FindAsync(id),
                pomList = await _context.pom
                    .Where(c => c.cex.id_cex == id)
                    .ToListAsync()
            };

            return View(pm);
        }

        // GET: //Cex/CreatePom/5
        public IActionResult CreatePom(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PomCreateViewModel pm = new()
            {
                id_cex = (int)id
            };

            return View(pm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePom([Bind("id_pom,pomName,id_cex")] PomCreateViewModel pmModel)
        {
            if (ModelState.IsValid)
            {
                Pom pm = new()
                {
                    cex = await _context.cex
                        .FindAsync(pmModel.id_cex),
                    pomName = pmModel.pomName
                };

                _context.pom.Add(pm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Pom), new { @id = pmModel.id_cex });
            }

            return View(pmModel);
        }


        private bool CexExists(int id)
        {
            return _context.cex.Any(e => e.id_cex == id);
        }


        public async Task<IActionResult> EditPom(int? id_pom)
        {
            if (id_pom == null) return NotFound();

            Pom pom = await _context.pom
                .Include(c => c.cex)
                .FirstOrDefaultAsync(p => p.id_pom == id_pom);

            PomCreateViewModel pm = new()
            {
                id_pom = pom.id_pom,
                pomName = pom.pomName,
                id_cex = pom.cex.id_cex
            };

            return View(pm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPom([Bind("id_pom,id_cex,pomName")] PomCreateViewModel pom)
        {
            if (pom.id_pom == 0 || pom.id_cex == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cex = await _context.cex
                .Include(c => c.appUser)
                .FirstOrDefaultAsync(c => c.id_cex == pom.id_cex);

                AppUsers user = await _users.Users
                    .FirstOrDefaultAsync(u => u.Id == cex.appUser.Id);

                if (cex == null)
                {
                    return NotFound();
                }

                await _users.AddToRoleAsync(user, "npodr");

                Pom pm = new()
                {
                    id_pom = pom.id_pom,
                    pomName = pom.pomName
                };

                _context.pom.Update(pm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Pom), new { @id = pom.id_cex });
            }

            return View(pom);
        }

        public async Task<IActionResult> DeletePom(int? id_pom)
        {
            if (id_pom == null) return NotFound();

            Pom pom = await _context.pom
                .Include(c => c.cex)
                .FirstOrDefaultAsync(p => p.id_pom == id_pom);

            int id_cex = pom.cex.id_cex;

            _context.pom.Remove(pom);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Pom), new { @id = id_cex });
        }

    }
}
