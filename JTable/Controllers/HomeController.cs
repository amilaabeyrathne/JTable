using AutoMapper;
using JTable.DataAccess;
using JTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JTable.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetStudentMarks() 
        {
            try
            {
                List<Marks> lstMarks = new List<Marks>();
                using (MarksEntities db = new MarksEntities())
                {
                    List<Mark> list = db.Marks.ToList();

                    Mapper.CreateMap<Mark, Marks>();
                    foreach (Mark item in list)
                    {
                        Marks m = Mapper.Map<Mark, Marks>(item);
                        lstMarks.Add(m);
                    }
                   
                }

                //lstMarks = db.Marks.ToList();
                return Json(new { Result = "OK", Records = lstMarks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }  
        
        }

        [HttpPost]
        public JsonResult Create(Marks Model)
        {
            try
            {
                using (MarksEntities db = new MarksEntities())
                {
                    Mark mark = new Mark();
                    mark.Name = Model.Name;
                    mark.TotalMarks = Model.TotalMarks;
                    mark.MarksObtained = Model.MarksObtained;
                    db.Marks.Add(mark);
                    db.SaveChanges();
                }
               
                return Json(new { Result = "OK", Record = Model }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }  
    }
}