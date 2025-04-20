using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListController : Controller
    {
        private readonly ApplicationDbContext _Context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var ToDoLists = _Context.ToDoLists;
            return View(ToDoLists.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CrudList crudList)
        {
            _Context.ToDoLists.Add(crudList);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var DoLists= _Context.ToDoLists.Find(id);
            return View(DoLists);
        }
        [HttpPost]
        public IActionResult Edit(CrudList crudList)
        {
            _Context.ToDoLists.Update(crudList);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var DoLists = _Context.ToDoLists.Find(id);
            if (DoLists != null)
            {
                _Context.Remove(DoLists);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage");

            }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
