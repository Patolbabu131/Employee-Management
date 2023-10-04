using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class SalariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalariesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Example(int id)
        {
            var draft = _context.Salaries.ToList().Select(d => d.Emp_No == id);
            return PartialView("Details");
        }
        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Salaries.Include(s => s.id);
            return View(await applicationDbContext.ToListAsync());
        }

        public ActionResult Details(int id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Employees = _context.Employes.Where(m => m.Emp_No == id).ToList();
           
            mymodel.Salaries = _context.Salaries.Where(m => m.Emp_No == id).ToList();

            return PartialView("Details", mymodel);
        }
       
        public async Task<IActionResult> Create1(int? id)
        {
            var employee = await _context.Employes.FindAsync(id);
            ViewBag.Message = employee;
            return PartialView("Create");
        }

        // POST: Salaries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sal_Id,Emp_No,Basic,DA,HRA,FA,ME,SM,SY,month_year")] Salary salary)
        {
            
                _context.Add(salary);
                await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            ViewData["Emp_No"] = new SelectList(_context.Employes, "Emp_No", "Emp_No", salary.Emp_No);
            return View(salary);
        }

        // POST: Salaries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sal_Id,Emp_No,Basic,DA,HRA,FA,ME,SM,SY,month_year")] Salary salary){
            if (id != salary.Sal_Id){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException){
                    if (!SalaryExists(salary.Sal_Id)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Emp_No"] = new SelectList(_context.Employes, "Emp_No", "Emp_No", salary.Emp_No);
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries
                .Include(s => s.id)
                .FirstOrDefaultAsync(m => m.Sal_Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

  
        private bool SalaryExists(int id)
        {
            return _context.Salaries.Any(e => e.Sal_Id == id);
        }
    }
}
