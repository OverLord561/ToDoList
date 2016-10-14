using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
      

        // GET: Tasks
        public ActionResult Index()
        {
            ViewBag.List = To_dO_List.taskList;
            return View(To_dO_List.taskList);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int id)
        {
            TASK task = To_dO_List.taskList.Find(x => x.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id + 1;
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(TASK task)
        {
            if (ModelState.IsValid)
            {
                int elemCounts = To_dO_List.taskList.Count;
                task.Id = elemCounts;
                To_dO_List.taskList.Add(task);
                
                
                return RedirectToAction("Index", "Tasks");
            }

            return View(To_dO_List.taskList);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id  )
        {
         
            TASK task = To_dO_List.taskList.Find(x => x.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = id + 1;
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public ActionResult Edit(TASK task)
        {
            
            if (ModelState.IsValid)
            {
              
                foreach (var prop in To_dO_List.taskList)
                {
                    if (prop.Id == task.Id)
                    {
                        prop.Id = task.Id;
                        prop.Title = task.Title;
                        prop.Description = task.Description;
                        prop.Date = task.Date;
                        prop.IsReady = task.IsReady;
                    }
                }

               
                return RedirectToAction("Index", "Tasks");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id )
        {
            TASK task = To_dO_List.taskList.Find(x => x.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id + 1;
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete( int id ,  string title)
        {
            TASK task = To_dO_List.taskList.Find(x => x.Id == id);
           
            To_dO_List.taskList.Remove(task);
            return RedirectToAction("Index", "Tasks");
        }
    }
}
