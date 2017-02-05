using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Contexts;
using WebClient.Models;
using WebClient.Repositories;
using WebClient.ViewModels;

namespace WebClient.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Add()
        {
            var vm = new EmployeeViewModel();
            vm.Languages = new CRUDRepository<ProgrammingLanguage>().All(x => !x.Deleted);
            vm.Departments = new CRUDRepository<Department>().All(x => !x.Deleted);
            vm.Sexs = new CRUDRepository<Sex>().All(x => !x.Deleted);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel Model)
        {
            using (var db = new SiteDbContext())
            {
                var Emp = new Employee()
                {
                    Name = Model.Name,
                    Surname = Model.Surname,
                    Age = Model.Age,
                    Sex = Model.Sex,
                    Department = Model.Department
                };

                Emp.Create();


                new Experience()
                {
                    Employee = Emp.Id,
                    Language = Model.Language
                }.Create();

                return RedirectToAction("Read");
            }
        }

        public ActionResult Read(Employee Search)
        {
            var repo = new CRUDRepository<Employee>();
            var Model = new List<Employee>();

            if (Search != null && !string.IsNullOrWhiteSpace(Search.Name))
                Model = repo.All(x => !x.Deleted
                    && x.Name.ToLower().Contains(Search.Name));
            else
                Model = repo.All(x => !x.Deleted);

            ViewBag.Searched = Search.Name;
            return View(Model);
        }

        public ActionResult Update(Int32 Id)
        {
            return View(new Employee().Read(Id));
        }
        [HttpPost]
        public ActionResult Update(Employee Model)
        {
            var Result = Model.Update();

            var exp = new Experience().Read(Model.Experience);
            exp.Language = Model.Language;
            exp.Update();

            return RedirectToAction("Read");
        }

        [HttpGet]
        public ActionResult Delete(Int32 IdDeletingItem)
        {
            var Model = new Employee().Read(IdDeletingItem);
            Model.Deleted = true;
            Model.Update();
            return RedirectToAction("Read");
        }
    }
}