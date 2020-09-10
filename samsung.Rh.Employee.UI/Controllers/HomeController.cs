using Microsoft.Ajax.Utilities;
using samsung.Rh.Employee.Domain.Entities;
using samsung.Rh.Employee.Reposiory.Repositories;
using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace samsung.Rh.Employee.UI.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repo = new EmployeeRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Employees mod)
        {
              if (ModelState.IsValid)
                {
                    repo.Registro(mod);
                     TempData["ViewBag.MsgSuccess"] = "Registro feito com sucesso!";
                    return RedirectToAction("Index");
                }
          
           
            return View();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeList(string Name)
        {
            var employeeList = repo.GetEmployeesPerName(Name);
            if (employeeList != null)
            {

                return View(employeeList.ToList());
            }
            else
            {
                ViewBag.MsgError = "Nenhum dados encontrado";
            }
            return View();
        }
        public ActionResult ListarCliente()
        {
            return View();
        }
        public ActionResult Editar(int id)
        {

            Employees mod = new Employees();
            mod = repo.GetId(id);
            if (mod != null)
            {
                TempData["Id"] = mod.Id;
            }
            var employees = repo.GetEmployees(id);

            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Employees mod, int id)
        {
            TempData["id"] = mod.Id;
            return View();
        }

    }
}