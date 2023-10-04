using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Net;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class EmployeeController : Controller
    {
       
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public JsonResult EmployeeList()
        {
            var data = _db.Employes.ToList();
            return new JsonResult(data);
        }
        
      
        public ActionResult partial()
        {
            DateTime nowdate= DateTime.Now;
            ViewBag.Message = nowdate;
            return PartialView("Create");
        }

        public ActionResult Call_Edit()
        {
            return PartialView("Edit");
        }

     
        
        [HttpPost]
        public JsonResult Create_Emp(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Add(employee);
                _db.SaveChanges();
            }   
                return Json("success");
        }
     

        private JsonResult Json(string v, object allowGet)
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {    
            IEnumerable<Employee> objectCategoryList = _db.Employes;
            return View(objectCategoryList);
            
        }



        public async Task<IActionResult> EditPartial(int? id)
        {
            if (id == null || _db.Employes == null)
            {
                return NotFound();
            }

            var employee = await _db.Employes.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return PartialView("Edit", employee);
        }

        // POST: any/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Emp_No, [Bind("Emp_No,name,gender,DOB,DOJ,Contact_No")] Employee employee)
        {
            if (Emp_No != employee.Emp_No)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(employee);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Emp_No))
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
            return View(Index);
        }

        private bool EmployeeExists(int emp_No)
        {
            throw new NotImplementedException();
        }

        public JsonResult Delete(int id)
        {
            var data = _db.Employes.Where(e => e.Emp_No == id).SingleOrDefault();
            _db.Employes.Remove(data);
            _db.SaveChanges();
            return Json("success");
        }

        public async Task<IActionResult> Details(int? id)
        {
            var employee = await _db.Employes
                .FirstOrDefaultAsync(m => m.Emp_No == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee.name);
            return PartialView("Details");
        }
        public JsonResult NameOfEmp(int id)
        {
            var data = _db.Employes.Where(e => e.Emp_No == id).SingleOrDefault();
          
            return Json(data.name);
        }
        //public async Task<IActionResult> NameOfEmp(int? id)
        //{
        //    var employee = await _db.Employes
        //        .FirstOrDefaultAsync(m => m.Emp_No == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee.name);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emp_No,name,gender,DOB,DOJ,Contact_No")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }







    }
}
