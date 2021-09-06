using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTasks_Statuses.Models;

namespace WebAppTasks_Statuses.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            using(DbModels dbModel = new DbModels())
            {
                return View(dbModel.Tasks.ToList());
            }     
        }

        // GET: Task/Create
        public ActionResult Create(int id=0)//в WORK пусто
        {
            Tasks taskModel = new Tasks();
            using (DbModels db = new DbModels())
            {
                if (id != 0)
                    taskModel = db.Tasks.Where(x => x.ID == id).FirstOrDefault();
                taskModel.StatusesCollection = db.Statuses.ToList<Statuses>();
            }
            return View(taskModel);
            //return View();////////////////////////// WORK
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(Tasks task)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Tasks.Add(task);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            Tasks taskModel = new Tasks();
            using (DbModels db = new DbModels())
            {
                if (id != 0)
                    taskModel = db.Tasks.Where(x => x.ID == id).FirstOrDefault();
                taskModel.StatusesCollection = db.Statuses.ToList<Statuses>();
            }
            return View(taskModel);
            //using (DbModels dbModel = new DbModels())
            //{
            //    return View(dbModel.Tasks.Where(x => x.ID == id).FirstOrDefault());
            //}
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tasks task)
        {
            try
            {
                using(DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(task).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.Tasks.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    Tasks task = dbModel.Tasks.Where(x => x.ID == id).FirstOrDefault();
                    dbModel.Tasks.Remove(task);
                    dbModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
