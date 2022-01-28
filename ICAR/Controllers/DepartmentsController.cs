using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICAR.Models;

namespace ICAR.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ICARContext _context;

        public DepartmentsController(ICARContext context)
        {
            _context = context;
        }

        // GET: Departments
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        public async Task<IActionResult> Index()
        {
            this.SetCurrentBreadCrumbTitle("Departments");
            return View(await _context.Departments.ToListAsync());
        }
        public ActionResult getData(int draw, int start, int length, string strcode, string domain, int noCols)
        {
            string status = "";
            var v =

                _context.Departments.Where(a => a.Status != "Deleted").Select(a => new {


                    a.Code
                    , a.Name
                   
                    , a.ID
                     ,
                    a.Status




                });
            status = "success";






            var model = new
            {
                status
                ,
                data = v
            };
            return Json(model);
        }
        public JsonResult CreateUpdate(Department item, string Ttype)
        {

            string status = "";
            string message = "";

            try
            {
                if (Ttype == "new")
                {
                    
                    _context.Departments.Add(item);
                    _context.SaveChanges();


                }
                else
                {
                   
                    _context.Entry(item).State = EntityState.Modified;
                    _context.SaveChanges();

                }
                status = "success";
            }
            catch (Exception ex)
            {
                status = "fail";
                message = ex.Message;
            }

            var model = new
            {
                status,
                message
            };



            return Json(model);
        }
        public JsonResult Delete(int? id)
        {

            int userid = User.Identity.GetUserId();
            string status = "";
            string message = "";

            try
            {
                Department detail = _context.Departments.Find(id);

                detail.Status = "Deleted";
                _context.Entry(detail).State = EntityState.Modified;
                _context.SaveChanges();

                status = "success";
            }
            catch (Exception ex)
            {
               message = ex.InnerException.InnerException.Message;
               status = "failed";
            }

            Log log = new Log();
            log.Descriptions = "Delete UOM Record. ID:" + id;
            log.UserId = userid.ToString();
            _context.Logs.Add(log);
            _context.SaveChanges();

            var model = new
            {
                status,
                message
            };


            return Json(model);
        }
        public JsonResult ShowDetails(int? id)
        {

            string status = "";
            string message = "";
            string code = "";
            string description = "";


            try
            {
                var item = _context.Departments.Find(id);
                code = item.Code;
                description = item.Name;
                status = "success";
            }
            catch (Exception ex)
            {


                message = ex.Message;
                status = "fail";
            }


            var model = new
            {
                status,
                message,
                code,
                description
            };


            return Json(model);
        }
    }
}