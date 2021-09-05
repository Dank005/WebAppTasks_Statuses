using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTasks_Statuses.Models;

namespace WebAppTasks_Statuses.Controllers
{
    public class TasksController : Controller //list of statuses
    {
        // GET: Tasks
        public ActionResult AddOrEdit(int id=0)
        {
            Tasks taskModel = new Tasks();
            using (DbModels db = new DbModels())
            {
                if (id != 0)
                    taskModel = db.Tasks.Where(x => x.ID == id).FirstOrDefault();
                taskModel.StatusesCollection = db.Statuses.ToList<Statuses>();
            }
            return View(taskModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Tasks task)
        {
            return View();
        }
    }
}