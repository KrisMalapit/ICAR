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
    public class EquipmentTypesController : Controller
    {
        private readonly ICARContext _context;

        public EquipmentTypesController(ICARContext context)
        {
            _context = context;
        }

        // GET: EquipmentTypes
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        public async Task<IActionResult> Index()
        {
            this.SetCurrentBreadCrumbTitle("EquipmentTypes");
            ViewData["CompanyId"] = new SelectList(_context.Companies.Where(a=>a.Status == "Active"), "ID", "Name");
            return View(await _context.EquipmentTypes.ToListAsync());
        }
        public ActionResult getData(int draw, int start, int length, string strcode, string domain, int noCols)
        {
            string status = "";
            var v =

                _context.EquipmentTypes.Include(a=>a.Companies).Where(a => a.Status != "Deleted").Select(a => new {


                    a.Code
                    , a.DimensionCode
                   
                    , a.ID
                   ,a.CompanyId
                     ,
                    a.Status
                    ,Company = a.Companies.Name



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
        public JsonResult CreateUpdate(EquipmentType item, string Ttype)
        {

            string status = "";
            string message = "";

            try
            {
                if (Ttype == "new")
                {
                    
                    _context.EquipmentTypes.Add(item);
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
                EquipmentType detail = _context.EquipmentTypes.Find(id);

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
            string dimensioncode = "";
            int companyid = 0;


            try
            {
                var item = _context.EquipmentTypes.Find(id);
                code = item.Code;
                dimensioncode = item.DimensionCode;
                companyid = item.CompanyId;
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
                dimensioncode,
                companyid
            };


            return Json(model);
        }
    }
}